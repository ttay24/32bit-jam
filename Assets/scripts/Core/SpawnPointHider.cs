using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointHider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
            meshRenderer.enabled = false;
    }
}
