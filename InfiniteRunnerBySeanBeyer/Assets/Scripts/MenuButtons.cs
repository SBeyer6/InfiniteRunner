using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    public void Leaderboard()
    {
        GameManager.Instance.GoToLeaderboardScene();
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
