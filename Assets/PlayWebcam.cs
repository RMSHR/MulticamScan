using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class PlayWebcam : MonoBehaviour {

    public string deviceName = "";

    RawImage rawimage;
    Material _material;
    public Text infoText;
    WebCamTexture webcamTexture;

    void Start () {
		if(deviceName == "")
        {
            // show devices name
            WebCamDevice[] devices = WebCamTexture.devices;
            for (int i = 0; i < devices.Length; i++)
                Debug.Log(devices[i].name);

            enabled = false;
            return;
        }

        webcamTexture = new WebCamTexture(deviceName);
        rawimage = GetComponent<RawImage>();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        webcamTexture.Play();

        infoText.text =
            "Device name : "+deviceName+"\n"+
            "FPS: <TODO>";
    }

    private void Update()
    {
        infoText.text =
            "Device name : " + deviceName + "\n" +
            "FPS: <TODO>";
    }

}
