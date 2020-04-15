using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour {

    [SerializeField] private NetworkManager networkManager;
    [SerializeField] private Color clickColor;
    [SerializeField] private string cameraName = "Logi Capture";
    [SerializeField] private MeshRenderer cameraOutput;

    private void Start() {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (var i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);

        WebCamTexture webcam = new WebCamTexture();
        cameraOutput.material.mainTexture = webcam;
        webcam.Play();
    }

    // Update is called once per frame
    private void Update() {
        if(Input.GetMouseButton(0) && networkManager.status == Status.SELECT_COLOR) {
            Vector2 pos = Input.mousePosition; // Mouse position
            RaycastHit hit;
            Camera _cam = Camera.main; // Camera to use for raycasting
            Ray ray = _cam.ScreenPointToRay(pos);
            Physics.Raycast(_cam.transform.position, ray.direction, out hit, 10000.0f);
            if (hit.collider) {
                WebCamTexture camTexture = (WebCamTexture) hit.collider.gameObject.GetComponent<Renderer>().material.mainTexture;
                Texture2D tex = new Texture2D(camTexture.width, camTexture.height);
                tex.SetPixels(camTexture.GetPixels());
                tex.Apply();
                clickColor = tex.GetPixelBilinear(hit.textureCoord2.x, hit.textureCoord2.y); // Get color from texture
                networkManager.SendImage(tex);
                networkManager.SendQRColor(clickColor);
            }
        }
    }
}
