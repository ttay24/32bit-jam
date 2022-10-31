using System;
using UnityEngine;

[CreateAssetMenu(fileName = "item-pickup", menuName = "JAMMING/ItemPickup")]
public class ItemPickupData : ScriptableObject
{
    public string Id = Guid.NewGuid().ToString();
    public ItemPickupType PickupType;
    public Sprite Icon;
    public int MaxCount = 1;

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