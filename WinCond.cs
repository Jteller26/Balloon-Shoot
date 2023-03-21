using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCond : MonoBehaviour
{
    public GameObject checkmarksOne;
    public GameObject checkmarksTwo;
    public GameObject checkmarksThree;
    public Score scoreScript;
    public TextMeshProUGUI checkmarksNumber;
    public TextMeshProUGUI congrats;
    public GameObject lastMenu;
    public void DetermineWin()
    {
        //determines the winning conditions based on the score
        lastMenu.SetActive(true);
        if (scoreScript.score < 20)
        {
            //if score is less than 20, player will get 0 wildcats and be prompted to play again
            checkmarksNumber.text = "You receieved 0/3 checkmarks";
            congrats.text = "Try again?";
        }

        if (scoreScript.score > 20)
        {
            //if score is more than 20, first wildcat is enabled along with text
            //that notifys that the player has passed
            checkmarksOne.SetActive(true);
            checkmarksNumber.text = "You receieved 1/3 checkmarks";
            congrats.text = "You passed!";
            if (scoreScript.score > 50)
            {
                //if score is more than 50, the second wildcat is enabled
                //same text as having one wildcat
                checkmarksTwo.SetActive(true);
                checkmarksNumber.text = "You receieved 2/3 checkmarks";
                congrats.text = "You passed!";
                if (scoreScript.score > 100)
                {
                    //if score is more than 100, the last wildcat is enabled
                    //text is changed to let the player know they got all wildcats
                    checkmarksThree.SetActive(true);
                    congrats.text = "You got them all!";
                    checkmarksNumber.text = "You receieved 3/3 checkmarks";
                }
            }
        }
    }
}
