using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //makes the game paused by making time scale 0
    public void PreStart()
    {
        Time.timeScale = 0;
    }
    //makes game time scale 1 so all methods work 
    public void BeginGame()
    {
        Time.timeScale = 1;
    }
    // loaads scene 0 to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
	//exits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
