using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Playerinput : MonoBehaviour{

    // Start is called before the first frame update
    public Animator footballAnimator;
    public Animation footballAnimation;
    public Text pointsText;
    int selectRandomPlayerNumber;
    int points = 0;
    public GameObject FootballGameObject;
    Vector3 footballstartingposition;

    public Button throwButton;
    public Button tryButton;

    private bool enablereset = true;
    void Start(){

        Random.InitState(2342);
        footballstartingposition = FootballGameObject.transform.position;

    }


    public void ResetFootballPosition() {


        FootballGameObject.transform.position = footballstartingposition;
        footballAnimator.SetInteger("footballer", 9);
        tryButton.gameObject.SetActive(false);
        throwButton.gameObject.SetActive(true);
    }

    void AddPoint() {

        points = points + 1;
        pointsText.text = "Points: " + points.ToString();
        enablereset = true;
        CancelInvoke();
    }

    void ReEnableReset() {

        enablereset = true;

        tryButton.gameObject.SetActive(true);

        CancelInvoke();
    }

    public void ThrowFootball() {

        Debug.Log("working");

        selectRandomPlayerNumber = Random.Range(1, 9);
        footballAnimator.SetInteger("footballer", selectRandomPlayerNumber);

        enablereset = false;
        throwButton.gameObject.SetActive(false);

        if (selectRandomPlayerNumber == 1 || selectRandomPlayerNumber == 2 || selectRandomPlayerNumber == 3 || selectRandomPlayerNumber == 4) {


            Debug.Log("adding a point");
            Invoke("AddPoint", 0.9f);

        } else {

            Invoke("ReEnableReset", 0.9f);

        }

    }


    // Update is called once per frame
    void Update() {


        if (enablereset == true) {

            if (Input.GetKeyDown(KeyCode.R)) {

                ResetFootballPosition();
                enablereset = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            ThrowFootball();
            
        }

    

    }
}
