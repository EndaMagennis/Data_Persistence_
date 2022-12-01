using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] TMP_InputField playerNameInputField;
    [SerializeField] TMP_Text HighScore;
    public List<string> leaderboard;



    private void Start()
    {
        PlayerDataManager.Instance.LoadPlayerData();
        HighScore.text = "Best player: " + PlayerDataManager.Instance.bestPlayer + ": " + PlayerDataManager.Instance.bestScore;

    }

    private void Update()
    {
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);        
    }

    public void ViewLeaderBoard()
    {
        SceneManager.LoadScene(2);
    }

    public void ResetBestPlayer()
    {
        PlayerDataManager.Instance.SavePlayerData(null, 0, new List<string>{null});
        PlayerDataManager.Instance.LoadPlayerData();
        HighScore.text = "Best player: " + PlayerDataManager.Instance.bestPlayer + ": " + PlayerDataManager.Instance.bestScore;

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
