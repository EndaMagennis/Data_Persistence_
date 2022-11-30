using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;
    public int score;
    public string playerName;
    public string bestPlayer;
    public int bestScore;
 
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class PlayerData
    {
        public string savePlayer;
        public int saveScore;
    }

    //saving playerdata
    public void SavePlayerData(string bestPlayer, int bestScore)
    {
        PlayerData data = new PlayerData();
        data.savePlayer = bestPlayer;
        data.saveScore = bestScore;

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

            bestPlayer = data.savePlayer;
            bestScore = data.saveScore;
        }
    }

    

}
