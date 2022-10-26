using Jam.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryGoal : SceneLoader
{
    [SerializeField]
    public string VictoryScene = "Scenes/game/overworld/overworld-main";

    private void Start()
    {
        Debug.Log("scene: " + string.Join(", ", SceneManager.GetAllScenes().Select((s) => s.name).ToList()));
        //PlayerPrefs
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger collision");
        Debug.Log(other);
        if (other.gameObject.tag.Contains("Player"))
        {
            base.LoadLevel(new List<string> { VictoryScene });
        }
    }
}
