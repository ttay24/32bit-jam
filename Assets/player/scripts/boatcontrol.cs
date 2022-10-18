using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatcontrol : MonoBehaviour
{
    public Vector3 direction;
    public Transform theback;
    public float steering = 0;
    public float steeringpower = 200f;
    public float maxspeed = 5f;
    public float power;
    public Rigidbody rb;
    public Quaternion StartRot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.forward;
        steering = 0;
        if (Input.GetAxis("Horizontal") > 0)
        {
            steering = 1;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            steering = -1;
        }
        transform.Rotate(0,steering * steeringpower*Time.deltaTime,0 );

    }
}
