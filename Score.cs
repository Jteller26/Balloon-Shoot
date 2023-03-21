using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //get ui text and make  int for the score
    private TextMeshProUGUI scoretext;
    public int score;

    public int highScore;
    private const string highScoreKey = "HighScore";
    // Start is called before the first frame update
    void Start()
    {
        //get text ui component
        scoretext = GetComponent<TextMeshProUGUI>();
        highScore = PlayerPrefs.HasKey(highScoreKey) ? PlayerPrefs.GetInt(highScoreKey) : 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
         
       
    }
    public void addScore()
    {
        //add 1 to score
        score++;
        scoretext.text = score.ToString();
    }
    public void subtractScore()
    {
        //subract 1 to score
        score--;
        scoretext.text = score.ToString();
    }

    private void UpdateScoreText()
    {
        scoretext.text = "\nHigh Score " + highScore.ToString();
    }

    public void EndGame()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(highScoreKey, highScore);
        }
    }
}
