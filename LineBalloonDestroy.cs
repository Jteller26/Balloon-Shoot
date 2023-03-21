using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;


public class LineBalloonDestroy : MonoBehaviour
{
    float time = 1f; // creates flaot for my time hitting balloon
    public Score score; //gets the score of the score script
    public GameObject hitBalloon; //gets the balloon object
    public MeshRenderer[] theColors; // meshrender for object color
    public StartGame game; // gets script of staart game script
    public GameObject instructionBoard;
    public GameObject startBoard;


    public GameObject goodExplosionPrefab; // gets good particle prefab
    GameObject goodExplosionInstance; // gets good particle to instaniate 

    public GameObject badExplosionPrefab; // gets bad particle prefab
    GameObject badExplosionInstance; // gets good particle to instaniate 

    public AudioSource startAudio;
    public AudioSource popAudio;
    public AudioSource explodeAudio;

    private Color originalColor;


    void Start()
    {
        //when game staarts crosshair is blue and game is in prestart mode
        transform.GetComponentInChildren<LineRenderer>().material.color = Color.blue;
        game.PreStart();
    }

    void Update()
    {
        RaycastHit hit;
        Transform controller = GameObject.FindWithTag("RightHand").transform; // or use your specific controller object
        Ray ray = new Ray(controller.position, controller.forward);

        if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Balloon"))
        {
            //sets crosshair color to green and changes balloon color to green
            //upon ray hitting balloon
            transform.GetComponentInChildren<LineRenderer>().material.color = Color.green;
            hitBalloon = hit.transform.gameObject;
            theColors = hitBalloon.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer child in theColors)
            {
                if (originalColor == null)
                {
                    originalColor = child.material.color;
                }
                child.material.color = Color.green;
            }
        }
        else if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Red Balloon"))
        {
            //sets crosshair color to red when hitting red balloon
            transform.GetComponentInChildren<LineRenderer>().material.color = Color.red;
            hitBalloon = hit.transform.gameObject;
            theColors = hitBalloon.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer child in theColors)
            {
                if (originalColor == null)
                {
                    originalColor = child.material.color;
                }
                child.material.color = Color.red;
            }
        }
        else
        {
            //sets crosshair color back to blue
            transform.GetComponentInChildren<LineRenderer>().material.color = Color.blue;

            //reset balloon color to original color
            if (hitBalloon != null && originalColor != null)
            {
                foreach (MeshRenderer child in theColors)
                {
                    if (child.gameObject.tag == "Red Balloon") // check if the balloon is red
                    {
                        child.material.color = new Color(1f, 0f, 0f, 0.5f); // set transparent red color
                    }
                    else
                    {
                        child.material.color = originalColor; // set the original color for other balloons
                    }
                }
            }

            // set the original color to red transparent for red balloons and green transparent for other balloons
            if (hitBalloon != null)
            {
                if (hitBalloon.tag == "Red Balloon")
                {
                    originalColor = new Color(1f, 0f, 0f, 0.5f);
                }
                else
                {
                    originalColor = new Color(0f, 1f, 0f, 0.5f);
                }
            }
        }


            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Balloon"))
        {
            //destroys balloon if ray is on it for certain time 
            //resets timer and adds to score
            time += 1 * Time.deltaTime;
            if (time >= 1.5)
            {
                StartCoroutine(UpdatePop());
                Destroy(hit.collider.gameObject);
                time = 1;
                score.addScore();
            }
        }

        if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Red Balloon"))
        {
            //destroys balloon if ray is on it for certain time, also changes color to red
            //resets timer and subtracts from score 
            hitBalloon = hit.transform.gameObject;
            theColors = hitBalloon.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer child in theColors)
            {
                child.material.color = Color.red;
            }
            time += 1 * Time.deltaTime;
            if (time >= 1.2)
            {
                StartCoroutine(UpdateBadPop());
                Destroy(hit.collider.gameObject);
                time = 1;
                score.subtractScore();
            }
        }
        if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Black Balloon"))
        {
            //changes black balloon color to black upon ray hitting it
            //if popped, black balloon is destroyed and game restarts
            hitBalloon = hit.transform.gameObject;
            theColors = hitBalloon.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer child in theColors)
            {
                child.material.color = Color.black;
            }
            time += 1 * Time.deltaTime;
            if (time >= 1.2)
            {
                StartCoroutine(UpdateBadPop());
                Destroy(hit.collider.gameObject);
                time = 1;
                game.RestartGame();
            }
        }

        //bool triggerPressed = false;
        //InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        //device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerPressed);

        // Check for collision with start object
       // bool hitStartObject = Physics.Raycast(transform.position, transform.forward, out hit) && hit.collider.CompareTag("Start Object");

        // Check for collision with restart object
       // bool hitRestartObject = Physics.Raycast(transform.position, transform.forward, out hit) && hit.collider.CompareTag("Restart Object");

        // Handle input
        //if (triggerPressed)
        //{
        //    if (hitStartObject)
        //    {
        //        // Start game
        //        startBoard.SetActive(false);
        //        instructionBoard.SetActive(false);
        //        startAudio.Play();
        //        game.BeginGame();
        //    }
        //    else if (hitRestartObject)
        //    {
        //        // Restart game
        //        startBoard.SetActive(true);
        //        game.RestartGame();
        //    }

            // if ((hit.collider.tag == "Start Object") && (Input.GetButtonDown("Fire1")))
            //  {
            //      //if you click start object begin game method is called
            //	//plays audio when player starts game
            //	startBoard.SetActive(false);
            //	instructionBoard.SetActive(false);
            //	startAudio.Play();
            //      game.BeginGame();
            //  }

            //    if ((hit.collider.tag == "Restart Object") && (Input.GetButtonDown("Fire1")))
            //    {
            //        //if you click start object restart game method is called
            //        startBoard.SetActive(true);
            //         game.RestartGame();
            //     }

        }

        public void startgame()
        {
            startBoard.SetActive(false);
            instructionBoard.SetActive(false);
            startAudio.Play();
            game.BeginGame();
        }

        public void restartgame()
        {
            startBoard.SetActive(true);
            game.RestartGame();
        }


        IEnumerator UpdatePop()
        {
            //instatiates confetti particle effect and plays balloon pop sound
            //destroys after 0.4 seconds.
            goodExplosionInstance = Instantiate(goodExplosionPrefab, hitBalloon.transform.position, hitBalloon.transform.rotation);
            popAudio = GameObject.Find("BirthdayConfetti(Clone)").GetComponent<AudioSource>();
            popAudio.Play();
            yield return new WaitForSeconds(.4f);
            Destroy(goodExplosionInstance);
        }
        IEnumerator UpdateBadPop()
        {
            //instantiates explosion particle effect and plays explosion sound
            //destroys after 1 second
            badExplosionInstance = Instantiate(badExplosionPrefab, hitBalloon.transform.position, hitBalloon.transform.rotation);
            explodeAudio = GameObject.Find("ExplosionMobileParticle(Clone)").GetComponent<AudioSource>();
            explodeAudio.Play();
            yield return new WaitForSeconds(1f);
            Destroy(badExplosionInstance);
        }
    
}
