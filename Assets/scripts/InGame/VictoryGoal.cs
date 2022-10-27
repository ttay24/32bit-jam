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
    [SerializeField]
    public LevelData LevelData;

    private void Start()
    {
        Debug.Log("scene: " + string.Join(", ", SceneManager.GetAllScenes().Select((s) => s.name).ToList()));
        //PlayerPrefs
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            GameEventDispatcher.DispatchOnVictoryTriggered(LevelData);

            // load the overworld (or victory scene)
            base.LoadLevel(new List<string> { VictoryScene });
        }
    }
}
