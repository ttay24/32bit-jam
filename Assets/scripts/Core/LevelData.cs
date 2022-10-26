using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level-data", menuName = "JAMMING/LevelData", order = 2)]
public class LevelData : ScriptableObject
{
    public string Id = Guid.NewGuid().ToString();
    public string SceneDisplayName;
    public List<string> ScenesToLoad;

    [ContextMenu("Generate ID")]
    void GenerateId()
    {
        Id = Guid.NewGuid().ToString();
    }
}
