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
    public Color activeColor, inactiveColor;
    public Image activeImage;

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
        // infos text
        infoText.text =
            "Device name : " + deviceName + "\n" +
            "FPS: <TODO>" + "\n" +
            "Size : " + webcamTexture.width + "x" + webcamTexture.height;

        // puce d'activite
        if(webcamTexture.isPlaying)
        {
            activeImage.color = activeColor;
        }
        else
        {
            activeImage.color = inactiveColor;
        }

        // input test
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
            snap.SetPixels(webcamTexture.GetPixels());
            snap.Apply();

            System.IO.File.WriteAllBytes("D:/Unity/captures/" + deviceName + ".png", snap.EncodeToPNG());
        }
    }

}
