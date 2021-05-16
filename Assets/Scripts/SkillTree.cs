using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerMovementScript;
    private Stealth playerStealthScript;
    private GameObject cam;

    private GameObject skillCanvas;
    [SerializeField] private TextMeshProUGUI pointsDisplay;
    [SerializeField] private TextMeshProUGUI[] skillRatios;
    [SerializeField] private Button[] buttons;
    private int currMoveIncrease = 0;
    private int currVisionIncrease = 0;

    [SerializeField] private int numOfPoints = 0;
    private bool skillStealth = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
        playerStealthScript = player.GetComponent<Stealth>();

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        skillCanvas = GameObject.Find("SkillCanvas");
        skillCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skillCanvas.activeSelf)
            {
                Time.timeScale = 1;
                skillCanvas.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                skillCanvas.SetActive(true);
            }
            
        }
    }

    public void GainPoint()
    {
        numOfPoints++;
        pointsDisplay.text = "Points: " + numOfPoints;
    }

    public void SkillIncreaseMovement()
    {
        if (numOfPoints >= 1 && currMoveIncrease < 6)
        {
            currMoveIncrease++;
            skillRatios[0].text = currMoveIncrease + "/6";
            ReducePoints(1);
            playerMovementScript.IncreaseMovement();

            if (currMoveIncrease >= 6)
            {
                buttons[0].interactable = false;
            }
        }
    }
    public void SkillIncreaseVision()
    {
        if (numOfPoints >= 1 && currVisionIncrease < 6)
        {
            currVisionIncrease++;
            skillRatios[1].text = currVisionIncrease + "/6";
            ReducePoints(1);
            cam.GetComponent<Camera>().orthographicSize += 2;

            if(currVisionIncrease >= 6)
            {
                buttons[1].interactable = false;
            }
        }

    }

    public void SkillStealth()
    {
        if(numOfPoints >= 3 && !skillStealth)
        {
            skillStealth = true;
            skillRatios[2].text = "1/1";
            ReducePoints(3);
            playerMovementScript.EnableSkillStealth();

            buttons[2].interactable = false;
        }
        
    }





    private void ReducePoints(int decrement)
    {
        numOfPoints -= decrement;
        pointsDisplay.text = "Points: " + numOfPoints;
    }
}
