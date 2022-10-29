using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    public ItemPickupData ItemPickupData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            GameEventDispatcher.Instance.DispatchOnItemPickup(ItemPickupData);
            Destroy(this.gameObject);
        }
    }
}
