using Jam.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldLevelLoader : SceneLoader
{
    [SerializeField]
    public List<Object> ScenesToLoad = new List<Object>();

    [SerializeField]
    public float CollisionRadius = 18.0f;

    private Transform PlayerTransform;
    private Color OriginalColor;
    private bool InRange = false;

    private void Awake()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        OriginalColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(PlayerTransform.position, gameObject.transform.position)) < CollisionRadius)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            InRange = true;

            // TODO: make this load happen on some type of input
            LoadScenes();
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = OriginalColor;
            InRange = false;
        }
    }

    public void LoadScenes()
    {
        LoadLevel(ScenesToLoad);
    }
}
