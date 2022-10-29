using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text PrisonerText;

    [SerializeField]
    TMP_Text KeysText;

    private void Start()
    {
        GameEventDispatcher.Instance.OnCurrentRunUpdated += OnCurrentRunUpdated;
    }

    private void OnDestroy()
    {
        GameEventDispatcher.Instance.OnCurrentRunUpdated -= OnCurrentRunUpdated;
    }

    private void OnCurrentRunUpdated(PlayerLevelData e)
    {
        PrisonerText.text = "PRISONERS " + e.PrisonersObtained;
        KeysText.text = "KEYS " + e.Keys;
    }
}
