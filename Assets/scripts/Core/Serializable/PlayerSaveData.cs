using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class PlayerSaveData : MonoBehaviour, ISerializationCallbackReceiver
{
    const string FILE_NAME = "player-save-data.json";
    
    // TODO
    public int Progress = 0;
    [SerializeField]
    public Dictionary<string, PlayerLevelData> LevelProgress = new Dictionary<string, PlayerLevelData>();
    // TODO: inventory

    private void Awake()
    {
        // TODO: pull in any dependencies after we load
    }

    private void Start()
    {
        // load in the level details
    }

    public void Save()
    {
        string fileName = string.Concat(Application.persistentDataPath, "/", FILE_NAME);
        Debug.Log(string.Format("Writing file: {0}", fileName));

        // serialize to json
        string jsonData = JsonUtility.ToJson(this, true);

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
    }

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(5, 5, 100, 50), "Save"))
        {
            this.Save();
        }

        if (GUI.Button(new Rect(5, 60, 100, 50), "Load"))
        {
            this.Load();
        }
    }
}

[Serializable]
public struct PlayerLevelData
{
    public string Id;
    public int PrisonersObtained;
    public bool LevelCompleted;
}
