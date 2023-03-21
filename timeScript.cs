using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float times;
    //create ui text for timer
    TextMeshProUGUI timeText;
	public WinCond winCondScript;

    public Score scoreScript;
    //Get component of ui text
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        scoreScript = GameObject.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    //every frame the time goes down and once at 0 it makes time scale to 0
    void Update()
    {
        times -= Time.deltaTime;
        timeText.text = times.ToString("f1");
        if (times <= 0)
        {
            scoreScript.EndGame();
            Time.timeScale = 0;
            //displays end screen once timer runs out
			if(Time.timeScale == 0)
				winCondScript.DetermineWin();						
        }
    }
}
