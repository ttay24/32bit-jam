using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
            GameEventDispatcher.DispatchOnSpotlightTriggered(other.gameObject);
    }
}
