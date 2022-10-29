using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class PlayerLevelProgressDictionary : UnitySerializedDictionary<string, PlayerLevelData> { }

[Serializable]
public class PlayerSaveData : MonoBehaviour, ISerializationCallbackReceiver
{
    const string FILE_NAME = "player-save-data.json";

    private static PlayerSaveData _instance;
    public static PlayerSaveData Instance { 
        get
        {
            return _instance;
        }
    }
    
    [SerializeField]
    public PlayerLevelProgressDictionary LevelProgress = new PlayerLevelProgressDictionary();
    // TODO: inventory

    private void Awake()
    {
        _instance = this;

        // TODO: pull in any dependencies after we load
    }

    private void Start()
    {
        this.Load();
    }

    private void OnEnable()
    {
        GameEventDispatcher.OnVictoryTriggered += GameEventDispatcher_OnVictoryTriggered;
    }

    private void OnDisable()
    {
        GameEventDispatcher.OnVictoryTriggered -= GameEventDispatcher_OnVictoryTriggered;
    }

    #region event handlers
    private void GameEventDispatcher_OnVictoryTriggered(object sender, EventArgs e)
    {
        LevelData levelData = (LevelData) sender;

        // get the level progress (or instantiate it)
        PlayerLevelData playerLevelData = GetPlayerLevelData(levelData);

        // mark completed
        playerLevelData.LevelCompleted = true;

        // upsert the object to the dictionary so that we can save the data
        LevelProgress.Upsert(playerLevelData.Id, playerLevelData);

        // save the progress
        this.Save();
    }

    #endregion

    public PlayerLevelData GetPlayerLevelData(LevelData levelData)
    {
        if (!LevelProgress.ContainsKey(levelData.Id))
        {
            PlayerLevelData playerLevelData = new PlayerLevelData();
            playerLevelData.Id = levelData.Id;
            LevelProgress.Upsert(levelData.Id, playerLevelData);
            return playerLevelData;
        }
        else
        {
            return LevelProgress[levelData.Id];
        }
    }

    public void Save()
    {
        string fileName = string.Concat(Application.persistentDataPath, "/", FILE_NAME);
        Debug.Log(string.Format("Writing file: {0}", fileName));

        // serialize to json
        string jsonData = JsonUtility.ToJson(this, true);
        Debug.Log(jsonData);

        // write the file
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(fileName))
        {
            bf.Serialize(file, jsonData);
            file.Close();
        }
    }

    public void Load()
    {
        string fileName = string.Concat(Application.persistentDataPath, "/", FILE_NAME);

        // check if file exists
        if (File.Exists(fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Open(fileName, FileMode.Open))
            {
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            }
        }

        Debug.Log(
            string.Join(
                ", ",
                this.LevelProgress
                .Select(k => string.Format("Id: {0}, completed: {1}, prisoners saved: {2}", k.Value.Id, k.Value.LevelCompleted, k.Value.PrisonersObtained))
                .ToList()
            )
        );
    }

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
    }

    private void OnGUI()
    {
        /*if (GUI.Button(new Rect(5, 5, 100, 50), "Save"))
        {
            this.Save();
        }

        if (GUI.Button(new Rect(5, 60, 100, 50), "Load"))
        {
            this.Load();
        }*/
    }
}

[Serializable]
public struct PlayerLevelData
{
    public string Id;
    public int PrisonersObtained;
    public bool LevelCompleted;
}
