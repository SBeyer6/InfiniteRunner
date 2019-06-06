using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    float currentScore;

    Text scoreText;

    //gets the score, rounded to two decimals by multiplying by 100 when rounding then dividing by 100
    public float Score { get { return (float)((int)currentScore * 100) * .01f; } }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //player travels at approx. 1m per second
        currentScore += Time.deltaTime;

        int rounded = (int)currentScore;

        scoreText.text = "Score: " + rounded.ToString();
    }
}
