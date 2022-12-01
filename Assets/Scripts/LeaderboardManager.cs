using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_Text scoreboad;
    

    private void Awake()
    {
        PopulateLeaderBoard();
    }

    public void ReturnToStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void PopulateLeaderBoard()
    {
        foreach(var name in PlayerDataManager.Instance.leaderboard)
        {
            scoreboad.text += name + "\n\r";
        }
    }
}
