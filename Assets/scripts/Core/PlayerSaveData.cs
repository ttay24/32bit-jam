using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSaveData : MonoBehaviour, ISerializationCallbackReceiver
{
    private void Awake()
    {
        // TODO: pull in any dependencies after we load
    }

    public void OnAfterDeserialize()
    {
        throw new NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
        throw new NotImplementedException();
    }
}
