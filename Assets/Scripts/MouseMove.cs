using System.Threading;
using NUnit.Framework.Constraints;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public Vector2 CameraLimit = new Vector2(-45, 40);

    float MouseX;
    float MouseY;
    float MouseSensivity = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        MouseX += Input.GetAxis("Mouse X") * MouseSensivity;
        MouseY += Input.GetAxis("Mouse Y") * MouseSensivity;
        // Apply camera limts
        MouseY = Mathf.Clamp(MouseY, CameraLimit.x, CameraLimit.y);

        transform.rotation = Quaternion.Euler(-MouseY, MouseX, 0);



    }
}
