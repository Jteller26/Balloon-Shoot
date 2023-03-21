using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairColor : MonoBehaviour
{
    //find corsshair immage
    // Start is called before the first frame update
    void Start()
    {
        //get the imaage component
        transform.GetComponentInChildren<LineRenderer>().material.color = Color.blue;
        //makes the image blue
        transform.GetComponentInChildren<LineRenderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {


    }
    //makes the image blue
    public void BlueCrosshair()
    {
        transform.GetComponentInChildren<LineRenderer>().material.color = Color.blue;
    }
    //makes image red
    public void RedCrosshair()
    {
        transform.GetComponentInChildren<LineRenderer>().material.color = Color.red;
    }
    //makes image green
    public void GreenCrosshair()
    {
        transform.GetComponentInChildren<LineRenderer>().material.color = Color.green;
    }
}
