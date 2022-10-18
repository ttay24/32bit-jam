using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimOnClick : MonoBehaviour
{
    public GameObject theReticle;
    public GameObject aimingCam;
    public GameObject normalCam;
    public GameObject mainCam;
    public GameObject thePlayer;
    public Vector3 cameraRot;
    public Vector3 playerRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thePlayer.transform.eulerAngles = new Vector3(thePlayer.transform.eulerAngles.x, mainCam.transform.eulerAngles.y, thePlayer.transform.eulerAngles.z);
        if (Input.GetButton("Fire2"))
        {
            theReticle.SetActive(true);
            aimingCam.SetActive(true);
            normalCam.SetActive(false);
            //thePlayer.transform.eulerAngles = new Vector3(thePlayer.transform.eulerAngles.x, mainCam.transform.eulerAngles.y, thePlayer.transform.eulerAngles.z);
        }
        
        else if (!Input.GetButton("Fire2"))
        {
            theReticle.SetActive(false);
            normalCam.SetActive(true);
            aimingCam.SetActive(false);
        }
    }
}
