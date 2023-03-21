using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour
{
    //get all gameobjects of my balloons
    public GameObject WhiteBalloon;
    public GameObject YellowBalloon;
    public GameObject BlueBalloon;
    public GameObject RedBalloon;
    public GameObject BlackBalloon;

    void Start()
    {
        //how often the balloons with spawn
        InvokeRepeating(nameof(WhiteBalloonSpawn), 1f, 2f);
        InvokeRepeating(nameof(YellowBalloonSpawn), 4f, 4f);
        InvokeRepeating(nameof(BlueBalloonSpawn), 5f, 6f);
        InvokeRepeating(nameof(RedBalloonSpawn), 20f, 5f);
        InvokeRepeating(nameof(BlackBalloonSpawn), 80f, 18f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // insaiate white balloon
    void WhiteBalloonSpawn()
    {
        Instantiate(WhiteBalloon, new Vector3(Random.Range(-6f, 6f), Random.Range(4.5f, 1.5f), Random.Range(-7f,-2f)), transform.rotation);
    }
    // insaiate yellow balloon
    void YellowBalloonSpawn()
    {
        Instantiate(YellowBalloon, new Vector3(Random.Range(-6f, 6f), Random.Range(4.5f, 1.5f), Random.Range(-7f, -2f)), transform.rotation);
    }
    // insaiate blue balloon
    void BlueBalloonSpawn()
    {
        Instantiate(BlueBalloon, new Vector3(Random.Range(-6f, 6f), Random.Range(4.5f, 1.5f), Random.Range(-7f, -2f)), transform.rotation);
    }
    // insaiate red balloon
    void RedBalloonSpawn()
    {
        Instantiate(RedBalloon, new Vector3(Random.Range(-6f, 6f), Random.Range(4.5f, 1.5f), Random.Range(-7f, -2f)), transform.rotation);
    }
    // insaiate black balloon
    void BlackBalloonSpawn()
    {
        Instantiate(BlackBalloon, new Vector3(Random.Range(-6f, 6f), Random.Range(5.5f, 1.5f), Random.Range(-7f, -5f)), transform.rotation);
    }
}
