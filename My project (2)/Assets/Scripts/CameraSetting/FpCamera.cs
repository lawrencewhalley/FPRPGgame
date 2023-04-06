using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpCamera : MonoBehaviour
{
    
   public cameraSettings playerCameraSettings;
   public Transform player;
   float xRotation = 0f;
   private float MouseSensitivity;

    void Start()
    {
        MouseSensitivity = playerCameraSettings.fpmouseSensitivity;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {

        float x = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * x);


    }
    
}
