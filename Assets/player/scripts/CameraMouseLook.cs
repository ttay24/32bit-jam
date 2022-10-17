using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{
    public Vector2 rotation = Vector2.zero;
    public float mouseSens = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * mouseSens;
        //this makes the camera rotate with the mouse
    }
}
