using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    public string playerName;
    public TMP_InputField playerNameInputField;
    public TMP_Text HighScore;


    private void Start()
    {
        PlayerDataManager.Instance.LoadPlayerData();
        HighScore.text = "Best player: " + PlayerDataManager.Instance.bestPlayer + ": " + PlayerDataManager.Instance.bestScore;
    }

  
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetBestPlayer()
    {
        if (PlayerDataManager.Instance.bestPlayer != null || PlayerDataManager.Instance.bestScore != 0)
        {
            PlayerDataManager.Instance.bestPlayer = null;
            PlayerDataManager.Instance.bestScore = 0;
        }
    }

    public void SetPlayerName()
    {
        playerName = playerNameInputField.text;
        PlayerDataManager.Instance.playerName = playerName;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
