using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public float projforce;
    public GameObject theGun;
    public GameObject theBullet;
    public GameObject theMuzzle;
    public float CoolDownTime;
    public bool canshoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (canshoot)
            {
                StartCoroutine(cooldown());
                GameObject projectile = (GameObject)Instantiate(theBullet, theMuzzle.transform.position, theMuzzle.transform.rotation);
                Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
                projectileRb.AddRelativeForce(projforce * Vector3.forward, ForceMode.Impulse);
            }
        }
    }
    IEnumerator cooldown()
    {
        canshoot = false;
        yield return new WaitForSeconds(CoolDownTime);
        canshoot = true;
    }
}
