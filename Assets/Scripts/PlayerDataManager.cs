using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;
    public static int HighScore;
    public static string PlayerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }
    [System.Serializable]
    public class PlayerData
    {
        public string Name;
        public int Score;
    }

    //saving playerdata
    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.Name = PlayerName;
        data.Score = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            PlayerName = data.Name;
            HighScore = data.Score;
        }
    }

}
