using System;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;
    float PlayerSpeed = 10;
    bool OnGround = false;
    //float MouseX = 0;
    //float MouseY = 0;
    //float MouseSpeed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            OnGround = true;
            Debug.Log("OnGround");
        }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        
        if(Input.GetKey(KeyCode.Space) && OnGround)
        {
            rb.AddForce(gameObject.transform.up * 200);
            OnGround = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(gameObject.transform.forward * PlayerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(gameObject.transform.forward * -1 * PlayerSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(gameObject.transform.right * PlayerSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(gameObject.transform.right * -1 * PlayerSpeed);
        }
    }

    // Update is called once per frame
   /*
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * MouseSpeed * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * MouseSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(MouseY, MouseX, 0);
    }
   */
}
