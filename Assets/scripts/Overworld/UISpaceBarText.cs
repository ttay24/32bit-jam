using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISpaceBarText : MonoBehaviour
{
    private TMP_Text UIText;

    private void Awake()
    {
        UIText = GetComponent<TMP_Text>();

        if (UIText == null)
        {
            Debug.LogWarning("UIText is null");
        }
    }

    private void OnEnable()
    {
        OverworldEventDispatcher.OnPlayerEnterLevelSelection += OverworldEventDispatcher_OnPlayerEnterLevelSelection;
    }

    private void OnDisable()
    {
        OverworldEventDispatcher.OnPlayerEnterLevelSelection -= OverworldEventDispatcher_OnPlayerEnterLevelSelection;
    }

    private void OverworldEventDispatcher_OnPlayerEnterLevelSelection(string levelName, PlayerEnterLevelSelectionArgs e)
    {
        // update the level text
        if (e.InRange)
            UIText.text = "PRESS SPACE";
        else
            UIText.text = "";
    }
}
