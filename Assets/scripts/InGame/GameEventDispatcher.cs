using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventDispatcher : MonoBehaviour
{
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
    public static event EventHandler OnObjectivePickup;
    public static void DispatchOnObjectivePickup(object sender, ObjectivePickupEventArgs args)
    {
        OnObjectivePickup?.Invoke(sender, args);
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
}

public class ObjectivePickupEventArgs : EventArgs
{
    public ObjectivePickupData PickupData;

    public ObjectivePickupEventArgs(ObjectivePickupData pickupData)
    {
        PickupData = pickupData;
    }
}
