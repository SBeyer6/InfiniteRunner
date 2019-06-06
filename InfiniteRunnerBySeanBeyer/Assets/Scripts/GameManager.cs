using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    float recentScore;

    public float RecentScore { get { return recentScore; } }

    public static GameManager Instance { get
        {
            if (instance != null)
                return instance;

            //create instance
            GameObject gm = new GameObject("GameManager");
            DontDestroyOnLoad(gm);
            instance = gm.AddComponent<GameManager>();
            return instance;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToGameOverScreen(float _score)
    {
        recentScore = _score;
        SceneManager.LoadScene("GameOverScene");
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GoToLeaderboardScene()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }
}
