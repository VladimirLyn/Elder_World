using System.Threading;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    float MouseX = 0;
    float MouseY = 0;
    float MouseSpeed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.rotation.x > 40 || gameObject.transform.rotation.x < -40)
        {
           
        }
        else
        {
            MouseX = Input.GetAxis("Mouse X") * MouseSpeed * Time.deltaTime;
        }
        
        MouseY = Input.GetAxis("Mouse Y") * MouseSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(MouseY, MouseX, 0);
    }
}
