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
        GameEventDispatcher.Instance.OnCurrentRunItemsUpdated += Instance_OnCurrentRunItemsUpdated;
    }

    private void OnDestroy()
    {
        GameEventDispatcher.Instance.OnCurrentRunUpdated -= OnCurrentRunUpdated;
        GameEventDispatcher.Instance.OnCurrentRunItemsUpdated -= Instance_OnCurrentRunItemsUpdated;
    }

    private void OnCurrentRunUpdated(PlayerLevelData e)
    {
        PrisonerText.text = "PRISONERS " + e.PrisonersObtained;
    }

    private void Instance_OnCurrentRunItemsUpdated(PlayerInventoryDictionary e)
    {
        Debug.Log("Instance_OnCurrentRunItemsUpdated");
        int keyCount = 0;
        if (e.ContainsKey(ItemPickupType.Key))
            keyCount = e[ItemPickupType.Key].ItemCount;

        KeysText.text = "KEYS " + keyCount;
    }
}
