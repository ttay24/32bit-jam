using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventDispatcher : MonoBehaviour
{
    public static GameEventDispatcher Instance;

    private void Awake()
    {
        Instance = this;
    }

    #region spotlight
    // event for when spotlights are triggered
    public static event EventHandler OnSpotlightTriggered;
    public static void DispatchOnSpotlightTriggered(object sender)
    {
        OnSpotlightTriggered?.Invoke(sender, null);
    }
    #endregion

    #region objective pickup
    // event for when spotlights are triggered
    public event Action<ObjectivePickupData> OnObjectivePickup;
    public void DispatchOnObjectivePickup(ObjectivePickupData args)
    {
        OnObjectivePickup?.Invoke(args);
    }
    #endregion

    #region victory reached
    // event for when spotlights are triggered
    public static event EventHandler OnVictoryTriggered;
    public static void DispatchOnVictoryTriggered(object sender)
    {
        OnVictoryTriggered?.Invoke(sender, null);
    }
    #endregion

    #region current run player data updated
    // event for when spotlights are triggered
    public event Action<PlayerLevelData> OnCurrentRunUpdated;
    public void DispatchCurrentRunUpdated(PlayerLevelData args)
    {
        OnCurrentRunUpdated?.Invoke(args);
    }
    #endregion
}

/*public class ObjectivePickupEventArgs : EventArgs
{
    public ObjectivePickupData PickupData;

    public ObjectivePickupEventArgs(ObjectivePickupData pickupData)
    {
        PickupData = pickupData;
    }
}*/
