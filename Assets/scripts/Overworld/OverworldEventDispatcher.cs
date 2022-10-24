using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldEventDispatcher : MonoBehaviour
{
    // event for when levels are in range
    public static event OnPlayerEnterLevelSelectionHandler OnPlayerEnterLevelSelection;
    public delegate void OnPlayerEnterLevelSelectionHandler(string levelName, PlayerEnterLevelSelectionArgs e);
    public static void DispatchOnPlayerEnterLevelSelection(string levelName, bool inRange)
    {
        OnPlayerEnterLevelSelection?.Invoke(levelName, new PlayerEnterLevelSelectionArgs(inRange));
    }
}



public class PlayerEnterLevelSelectionArgs : EventArgs
{
    public bool InRange;

    public PlayerEnterLevelSelectionArgs(bool inRange)
    { 
        InRange = inRange;
    }
}
