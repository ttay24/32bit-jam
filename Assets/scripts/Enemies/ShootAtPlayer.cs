using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public bool withinrange;
    public EnemyShipAI shipai;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            withinrange=true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            withinrange=false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (shipai.canshoot && withinrange)
        {
            shipai.Shoot();
        }
    }
}
