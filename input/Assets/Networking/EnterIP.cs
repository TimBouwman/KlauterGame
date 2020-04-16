using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterIP : MonoBehaviour {

    [SerializeField] private InputField inputField;
    [SerializeField] private SocketIO.SocketIOComponent socketIO;
    [SerializeField] private List<GameObject> objectsToEnable;

    public void IpEntered() {
        socketIO.serverIp = inputField.text;
        objectsToEnable.ForEach(obj => obj.SetActive(true));
        this.gameObject.SetActive(false);
    }

}
