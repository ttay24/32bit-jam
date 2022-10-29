using System;
using UnityEngine;

[CreateAssetMenu(fileName = "objective-pickup", menuName = "JAMMING/ObjectivePickup")]
public class ObjectivePickupData : ScriptableObject
{
    public string Id = Guid.NewGuid().ToString();
    public ObjectivePickupType PickupType;

    [ContextMenu("Generate ID")]
    void GenerateId()
    {
        Id = Guid.NewGuid().ToString();
    }
}

public enum ObjectivePickupType
{
    Prisoner,
    Note,
}