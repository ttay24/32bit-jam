using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LockMouse : MonoBehaviour
{
    public GameObject fullScreenButton;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    public void GoFullScreen()
    {
        Screen.fullScreen = true;
        Debug.Log("Going Fullscreen");
        fullScreenButton.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
