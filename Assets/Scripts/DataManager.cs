using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string nameActualPlayer;
    public int maxScore;
    public string nameMaxScorePlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SavePersistentData()
    {
        SaveData data = new SaveData();
        data.maxScore = maxScore;
        data.nameMaxScorePlayer = nameMaxScorePlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/datafile.json", json);
    }

    public void LoadPersistentData()
    {
        string path = Application.persistentDataPath + "/datafile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScore = data.maxScore;
            nameMaxScorePlayer = data.nameMaxScorePlayer;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int maxScore;
        public string nameMaxScorePlayer;
    }
}
