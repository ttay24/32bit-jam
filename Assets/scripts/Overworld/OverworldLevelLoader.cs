using Jam.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OverworldLevelLoader : SceneLoader
{
    [SerializeField]
    public List<string> ScenesToLoad = new List<string>();

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
            InRange = true;
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
