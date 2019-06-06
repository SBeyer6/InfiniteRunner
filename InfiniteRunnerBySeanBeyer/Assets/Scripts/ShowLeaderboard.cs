using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class ShowLeaderboard : MonoBehaviour
{
    [SerializeField]
    Text namesText;

    [SerializeField]
    Text scoresText;

    SortedList<float, string> highScores;

    // Start is called before the first frame update
    void Start()
    {
        LoadLeaderboard();
        PutLeaderboardOnUI();
    }

    void LoadLeaderboard()
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

    void PutLeaderboardOnUI()
    {
        //add name and scores to each row
        namesText.text = "";
        scoresText.text = "";
        for (int i = highScores.Count - 1; i >= 0; --i)
        {
            //put name on UI
            namesText.text += highScores.Values[i] + "\n";
            scoresText.text += highScores.Keys[i] + "\n";
        }
    }
}
