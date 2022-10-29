using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePickup : MonoBehaviour
{
    [SerializeField]
    public ObjectivePickupData ObjectivePickupData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            GameEventDispatcher.Instance.DispatchOnObjectivePickup(ObjectivePickupData);
            Destroy(this.gameObject);
        }
    }
}
