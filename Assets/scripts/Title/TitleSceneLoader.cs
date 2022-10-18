using Jam.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneLoader : SceneLoader
{
    [SerializeField]
    public string OverworldScene;

    public void StartGame()
    {
        base.LoadLevel(new List<string> { OverworldScene });
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
