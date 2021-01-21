using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewScript : MonoBehaviour
{
    public float mouseSens = 300f; //variable for players mouse sensitivity  
    public Transform playerBody; 
    float xRotate = 0f;
    
    
    
    void Start()
    {
        //so the mouse doesnt show while playing
        //Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -45f, 45f);//doesnt allow the player to move the camera to certain angles all directions 

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
