using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text PrisonerText;

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
        Debug.Log("UPDATING PRISONER TEXT..." + PrisonerText.text);
        PrisonerText.text = "PRISONERS " + e.PrisonersObtained;
        Debug.Log("UPDATED PRISONER TEXT...." + PrisonerText.text);
    }
}
