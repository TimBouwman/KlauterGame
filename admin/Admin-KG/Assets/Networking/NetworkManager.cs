using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

    public Status status;

    private const string connectionType = "admin";

    [SerializeField] private SocketIO.SocketIOComponent socket;
    [SerializeField] private TMPro.TextMeshProUGUI statusText;

    //private ArrayList players = new ArrayList();
    private bool joined = false;

    // Start is called before the first frame update
    void Start() {
        //Start listening to all the server events
        socket.On("redirectToServer", Redirect);
        socket.On("connect", OnConnection);
        socket.On("statusUpdate", StatusUpdate);
    }

    /* Send packets
     */
    
    public void SendImage(Texture2D texture) {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["encodedTexture"] = Convert.ToBase64String(texture.EncodeToJPG());
        data["textureWidth"] = "" + texture.width;
        data["textureHeight"] = "" + texture.width;

        socket.Emit("mapUpdate", new JSONObject(data));
    }

    public void SendQRColor(Color color) {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["r"] = "" + color.r;
        data["g"] = "" + color.g;
        data["b"] = "" + color.b;

        socket.Emit("colorUpdate", new JSONObject(data));
    }

    /* Direct responses
     */
    private void OnConnection(SocketIO.SocketIOEvent e) {
        if(!joined) {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["connectionType"] = connectionType;

            socket.Emit("join", new JSONObject(data));
        }
    }

    private void Redirect(SocketIO.SocketIOEvent e) {
        string eventAsString = "" + e.data;
        Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(eventAsString);

        socket.ReConnect(data["port"]);
        //Start registering new data
        this.Start();
    }

    /* Receive data from the server */

    private void OnDeviceJoin(SocketIO.SocketIOEvent e) {

    }

    private void StatusUpdate(SocketIO.SocketIOEvent e) {
        string eventAsString = "" + e.data;
        Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(eventAsString);

        this.status = Status.GetById(int.Parse(data["status"]));
        statusText.text = status.Name;
    }

}
