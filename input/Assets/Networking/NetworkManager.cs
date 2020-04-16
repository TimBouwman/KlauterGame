using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    private const string connectionType = "player";

    [SerializeField] private SocketIO.SocketIOComponent socket;

    private bool joined = false;

    // Start is called before the first frame update
    private void Start() {
        //Start listening to all the server events
        socket.On("redirectToServer", Redirect);
        socket.On("connect", OnConnection);
    }

    private void OnConnection(SocketIO.SocketIOEvent e) {
        if (!joined) {
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

    public void SendAppendagePositionUpdate(int index, Vector3 position) {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["id"] = "" + index;
        data["x"] = "" + position.x;
        data["y"] = "" + position.y;
        data["z"] = "" + position.z;

        socket.Emit("appendagePositionUpdate", new JSONObject(data));
    }

}
