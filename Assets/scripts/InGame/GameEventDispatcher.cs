using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventDispatcher : MonoBehaviour
{
    // event for when spotlights are triggered
    public static event EventHandler OnSpotlightTriggered;
    public static void DispatchOnSpotlightTriggered(object sender)
    {
        OnSpotlightTriggered?.Invoke(sender, null);
    }
}
