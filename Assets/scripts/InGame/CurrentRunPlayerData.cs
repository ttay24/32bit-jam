using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurrentRunPlayerData : MonoBehaviour
{
    [SerializeField]
    public PlayerLevelData PlayerLevelData;

    private void OnEnable()
    {
        // subscribe to any events
        //GameEventDispatcher.Instance.OnObjectivePickup += GameEventDispatcher_OnObjectivePickup;
    }

    private void OnDisable()
    {
        // unsubscribe from any events
        //GameEventDispatcher.Instance.OnObjectivePickup -= GameEventDispatcher_OnObjectivePickup;
    }


    private void Start()
    {
        var levelDataHolders = GameObject.FindObjectsOfType<LevelDataHolder>();

        if (levelDataHolders.Length > 0)
        {
            SetLevelId(levelDataHolders[0].LevelData?.Id);
        }

        // subscribe to any events
        GameEventDispatcher.Instance.OnObjectivePickup += GameEventDispatcher_OnObjectivePickup;
    }

    private void OnDestroy()
    {
        // unsubscribe from any events
        GameEventDispatcher.Instance.OnObjectivePickup -= GameEventDispatcher_OnObjectivePickup;
    }

    private void SetLevelId(string id)
    {
        PlayerLevelData.Id = id;
    }

    #region EVENTS
    private void GameEventDispatcher_OnObjectivePickup(ObjectivePickupData e)
    {
        switch (e.PickupType)
        {
            case ObjectivePickupType.Prisoner:
            {
                PlayerLevelData.PrisonersObtained++;
                break;
            }

            case ObjectivePickupType.Key:
            {
                PlayerLevelData.Keys++;
                break;
            }
        }

        // just go ahead and update it; something may have changed
        GameEventDispatcher.Instance.DispatchCurrentRunUpdated(PlayerLevelData);
    }
    #endregion
}
