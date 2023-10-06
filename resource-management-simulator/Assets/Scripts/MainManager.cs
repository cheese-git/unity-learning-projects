using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;
    string saveDataPath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        saveDataPath = Application.persistentDataPath + "/saveData.json";
        Instance = this;
        LoadColor();
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData saveData = new SaveData();
        saveData.TeamColor = TeamColor;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveDataPath, json);
    }

    void LoadColor()
    {
        if (File.Exists(saveDataPath))
        {
            string json = File.ReadAllText(saveDataPath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            TeamColor = saveData.TeamColor;
        }
    }
}
