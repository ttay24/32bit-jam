using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour
{
    public EnemyShipAI shipai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shipai.close = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shipai.close = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
