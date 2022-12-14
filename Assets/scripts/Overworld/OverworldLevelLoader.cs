using Jam.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OverworldLevelLoader : SceneLoader
{
    // level info
    // TODO: take in the level data; update this to dispatch the entire level data object (use name and stats for display)
    [SerializeField]
    LevelData LevelData;

    [SerializeField]
    public float CollisionRadius = 18.0f;

    // player stuff
    private GameObject Player;
    private Transform PlayerTransform;
    private PlayerInputActions PlayerInputActions;

    private Color OriginalColor;
    private bool InRange = false;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = Player?.transform;

        // setup player actions
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Overworld.Enable();

        // store the original color so we can reset it; this will probs get removed
        OriginalColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    private void OnEnable()
    {
        PlayerInputActions.Overworld.SelectLevel.performed += SelectLevel_performed;
    }

    private void OnDisable()
    {
        PlayerInputActions.Overworld.SelectLevel.performed -= SelectLevel_performed;
    }

    private void SelectLevel_performed(InputAction.CallbackContext obj)
    {
        // if player is in range when we select, then load the next level
        if (InRange)
        {
            LoadScenes();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(PlayerTransform.position, gameObject.transform.position)) < CollisionRadius)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;

            // if this wasn't in range, the it changed, so let's dispatch an event saying that it changed
            if (!InRange)
                OverworldEventDispatcher.DispatchOnPlayerEnterLevelSelection(LevelData.SceneDisplayName, LevelData, true);

            InRange = true;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = OriginalColor;

            // if we were in range, then we know we haven't unset it. We only want to do this 
            // once, otherwise we might overwrite other levels that are trying to display
            if (InRange)
                OverworldEventDispatcher.DispatchOnPlayerEnterLevelSelection(LevelData.SceneDisplayName, LevelData, false);

            InRange = false;
        }
    }

    public void LoadScenes()
    {
        LoadLevel(LevelData.ScenesToLoad);
    }
}
