using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    private const string connectionType = "output";

    [SerializeField] private SocketIO.SocketIOComponent socket;
    [SerializeField] private MeshRenderer cameraInput;
    [SerializeField] private Filter qRFilter;
    [SerializeField] private GameObject toEnableForQRConversion;
    [SerializeField] private ActiveRagdollController ragdollController;

    private ArrayList players = new ArrayList();
    private bool joined = false;

    // Start is called before the first frame update
    private void Start() {
        //Start listening to all the server events
        socket.On("redirectToServer", Redirect);
        socket.On("CameraInput", HandleCameraInput);
        socket.On("connect", OnConnection);
        socket.On("colorUpdate", HandleQRColorUpdate);
        socket.On("mapUpdate", ReceiveMapImage);
        socket.On("appendagePositionUpdate", OnAppendagePositionUpdate);
    }

    private void OnConnection(SocketIO.SocketIOEvent e) {
        if (!joined) {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["connectionType"] = connectionType;

            socket.Emit("join", new JSONObject(data));
        }
    }

    private void OnAppendagePositionUpdate(SocketIO.SocketIOEvent e) {
        string eventAsString = "" + e.data;
        Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(eventAsString);

        Vector3 pos = new Vector3(float.Parse(data["x"]), float.Parse(data["y"]), float.Parse(data["z"]));

        ragdollController.UpdateApandages(int.Parse(data["id"]), pos);
    }

    private void ReceiveMapImage(SocketIO.SocketIOEvent e) {
        if (toEnableForQRConversion.activeInHierarchy) {
            return;
        }

        string eventAsString = "" + e.data;
        Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(eventAsString);

        byte[] bytes = Convert.FromBase64String(data["encodedTexture"]);
        Texture2D newTexture = new Texture2D(int.Parse(data["textureWidth"]), int.Parse(data["textureHeight"]));
        newTexture.LoadImage(bytes);
        cameraInput.material.mainTexture = newTexture;
    }

    private void HandleQRColorUpdate(SocketIO.SocketIOEvent e) {
        if(toEnableForQRConversion.activeInHierarchy) {
            return;
        }

        string eventAsString = "" + e.data;
        Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(eventAsString);

        float r = float.Parse(data["r"]);
        float g = float.Parse(data["g"]);
        float b = float.Parse(data["b"]);
        print("r: " + r + ", g:" + g + ", b: " + b);
        qRFilter.color = new Color(r, g, b);

        toEnableForQRConversion.SetActive(true);
    }

    private void HandleCameraInput(SocketIO.SocketIOEvent e) {
        string eventAsString = "" + e.data;
        Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(eventAsString);

        Texture2D newMapInput = new Texture2D(1, 1);
        newMapInput.LoadImage(Convert.FromBase64String(data["imageAsBase64"]));
        newMapInput.Apply();
        this.cameraInput.material.SetTexture("camera input", newMapInput);
    }

    private void Redirect(SocketIO.SocketIOEvent e) {
        string eventAsString = "" + e.data;
        Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(eventAsString);

        socket.ReConnect(data["port"]);
        //Start registering new data
        this.Start();
    }

}
