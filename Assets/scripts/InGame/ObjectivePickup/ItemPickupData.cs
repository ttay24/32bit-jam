using System;
using UnityEngine;

[CreateAssetMenu(fileName = "item-pickup", menuName = "JAMMING/ItemPickup")]
public class ItemPickupData : ScriptableObject
{
    public string Id = Guid.NewGuid().ToString();
    public ItemPickupType PickupType;
    public Sprite Icon;

    [ContextMenu("Generate ID")]
    void GenerateId()
    {
        Id = Guid.NewGuid().ToString();
    }
}

public enum ItemPickupType
{
    Excavator,
    Harpoon,
    Key,
}