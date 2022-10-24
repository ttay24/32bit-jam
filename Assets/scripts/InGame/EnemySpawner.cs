using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Enemy;

    private List<Transform> SpawnPoints = new List<Transform>();

    private bool SpawnedEnemies = false;

    private void Awake()
    {
        // get all spawn points underneath this object
        SpawnPoints = GetComponentsInChildren<Transform>()?
            .Where((go) => go.tag == "SpawnPoint")?
            .ToList();
    }

    private void OnEnable()
    {
        // setup event to listen for (hard-coding for spotlight; if we need to expand this, we can make this class
        // extendable as a base class for common logic
        GameEventDispatcher.OnSpotlightTriggered += GameEventDispatcher_OnSpotlightTriggered;
    }

    private void OnDisable()
    {
        GameEventDispatcher.OnSpotlightTriggered -= GameEventDispatcher_OnSpotlightTriggered;
    }

    private void GameEventDispatcher_OnSpotlightTriggered(object sender, System.EventArgs e)
    {
        // if we've already spawned, then don't do it again
        if (SpawnedEnemies) return;
        SpawnedEnemies = true;

        // get the "sending" object (aka the triggering object) and cast it
        GameObject triggeringGameObject = sender as GameObject;

        // spawn enemy prefab at the spawn points
        foreach (Transform t in SpawnPoints)
        {
            // get rotation from the triggering object to the spawn point (so our enemy looks at the player)
            var rotation = Quaternion.LookRotation(triggeringGameObject.transform.position - t.position);
            GameObject.Instantiate(Enemy, t.position, rotation);
        }

    }
}
