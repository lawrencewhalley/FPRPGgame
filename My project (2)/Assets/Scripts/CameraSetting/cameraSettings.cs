using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSettings : MonoBehaviour
{
    public float mouseSensitivity;
    public float fpmouseSensitivity = 100f;

    public bool fpCameraEnabled = false;
    public Camera camera1;
    public Camera camera2;

    private void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    private void Update()
    {
        if (fpCameraEnabled == true)
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
    }


}
