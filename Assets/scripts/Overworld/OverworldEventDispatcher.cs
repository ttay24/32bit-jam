using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldEventDispatcher : MonoBehaviour
{
    // event for when levels are in range
    public static event OnPlayerEnterLevelSelectionHandler OnPlayerEnterLevelSelection;
    public delegate void OnPlayerEnterLevelSelectionHandler(string levelName, PlayerEnterLevelSelectionArgs e);
    public static void DispatchOnPlayerEnterLevelSelection(string levelName, LevelData levelData, bool inRange)
    {
        OnPlayerEnterLevelSelection?.Invoke(levelName, new PlayerEnterLevelSelectionArgs(levelData, inRange));
    }
}



public class PlayerEnterLevelSelectionArgs : EventArgs
{
    public LevelData LevelData;
    public bool InRange;

    public PlayerEnterLevelSelectionArgs(LevelData levelData, bool inRange)
    {
        LevelData = levelData;
        InRange = inRange;
    }
}
