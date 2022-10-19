using Jam.Core;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneLoader : SceneLoader
{
    [SerializeField]
    public string OverworldScene;
    public GameObject fullScreenButton;
    public void StartGame()
    {
        base.LoadLevel(new List<string> { OverworldScene });
    }
    public void GoFullScreen()
    {
        Screen.fullScreen = true;
        Debug.Log("Going Fullscreen");
        fullScreenButton.SetActive(false);

    }
    public void HowToPlay()
    {
        // TODO
    }

    public void Credits()
    {
        // TODO
    }

    public void ExitGame()
    {
        // TODO
    }

}
