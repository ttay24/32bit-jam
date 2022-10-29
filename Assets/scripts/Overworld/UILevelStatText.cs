using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelStatText : MonoBehaviour
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
        {
            PlayerSaveData.Instance.LevelProgress.TryGetValue(e.LevelData.Id, out var levelProgress);
            UIText.text = string.Format(
                "Level completed: {0}\nPrisoners Rescued: {1}", 
                levelProgress.LevelCompleted, levelProgress.PrisonersObtained
            );
        }
        else
            UIText.text = "";
    }
}
