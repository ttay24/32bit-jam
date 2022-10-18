using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtCrosshair : MonoBehaviour
{
    public Transform gunpoint;
    public Transform cam;
    public Transform Gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Gun.LookAt(gunpoint.position);
            //Gun.rotation = Quaternion.LookRotation(gunpoint.position);
            //if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo))
            //{
            //    Vector3 direction = hitInfo.point - Gun.position;
            //    Gun.rotation = Quaternion.LookRotation(direction);
            //}
        }
            
        
    }
}
