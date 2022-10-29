using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAI : MonoBehaviour
{
    public GameObject Cannon;
    public bool canshoot = true;
    public bool close;
    public GameObject ship;
    public GameObject distance;
    public GameObject bullet;
    public Rigidbody shipRB;
    public GameObject thePlayer;
    public float sailingSpeed;
    public float projforce;
    // Start is called before the first frame update
    void Start()
    {
        shipRB = ship.GetComponent<Rigidbody>();
        thePlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ship.transform.LookAt(thePlayer.transform);
        if (!close)
        {
            shipRB.AddForce(transform.forward * sailingSpeed * Time.deltaTime, ForceMode.Force);

        }

    }
    public void Shoot()
    {
        if (canshoot)
        {
            StartCoroutine(firecannons());
        }
    }
    IEnumerator firecannons()
    {
        canshoot = false;
        GameObject newbullet = Instantiate(bullet, Cannon.transform.position, Cannon.transform.rotation);
        newbullet.GetComponent<Rigidbody>().AddRelativeForce(projforce * Vector3.forward, ForceMode.Impulse);
        yield return new WaitForSeconds(3f);
        canshoot = true;
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Die();
        }
        
    }
    
    public void Die()
    {
        ship.SetActive(false);
    }
}
