using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class AddHighScore : MonoBehaviour
{
    [SerializeField]
    Text inputNameText;

    [SerializeField]
    int maxHighScores = 10;

    SortedList<float, string> highScores;

    string newName;

    float newScore;

    bool newHighScore;

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScores();
        newHighScore = false;

        if (highScores.Count < 1 || highScores.Keys[highScores.Count - 1] < GameManager.Instance.RecentScore || highScores.Count < maxHighScores)
        {
            //new high score!!
            newHighScore = true;
            newName = "";
            newScore = GameManager.Instance.RecentScore;
        }
        else
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadHighScores()
    {
        highScores = new SortedList<float, string>();
        if (!File.Exists("highscores.txt"))
            return;

        IFormatter formatter = new BinaryFormatter();

        //load from file
        FileStream fs = new FileStream("highscores.txt", FileMode.Open, FileAccess.Read);

        highScores = formatter.Deserialize(fs) as SortedList<float, string>;
        fs.Close();
    }

    public void AddCharacter(string letter)
    {
        newName += letter;
        inputNameText.text = newName;
    }

    private void OnDestroy()
    {
        if (!newHighScore)
            return;

        //add new high score
        highScores[newScore] = newName;

        IFormatter formatter = new BinaryFormatter();

        //load from file
        FileStream fs = new FileStream("highscores.txt", FileMode.OpenOrCreate, FileAccess.Write);

        formatter.Serialize(fs, highScores);
        fs.Close();
    }
}
