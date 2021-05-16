using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerMovementScript;
    private Stealth playerStealthScript;

    private GameObject cam;

    private bool skillStealth = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
        playerStealthScript = player.GetComponent<Stealth>();

        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            
        }

    }

    private void SkillStealth()
    {
        playerMovementScript.EnableSkillStealth();
    }

    private void SkillIncreaseVision()
    {
        cam.GetComponent<Camera>().orthographicSize++;
    }

    private void SkillIncreaseMovement()
    {
        playerMovementScript.IncreaseMovement();
    }
}
