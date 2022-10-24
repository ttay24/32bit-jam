using Jam.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryGoal : SceneLoader
{
    [SerializeField]
    public string VictoryScene = "Scenes/game/overworld/overworld-main";

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
