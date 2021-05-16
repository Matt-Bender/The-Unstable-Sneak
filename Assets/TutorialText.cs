using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialBoxes;
    [SerializeField] private TextMeshProUGUI tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == tutorialBoxes[0])
        {
            tutorialText.text = "WASD or Arrow Keys to move";
        }
        else if(collision.gameObject == tutorialBoxes[1])
        {
            tutorialText.text = "Avoid enemies vision";
        }
        else if(collision.gameObject == tutorialBoxes[2])
        {
            tutorialText.text = "Move over yellow square to collect";
        }
        else if(collision.gameObject == tutorialBoxes[3])
        {
            tutorialText.text = "Collect 3 yellow squares to unlock yellow door";
        }
        else if(collision.gameObject == tutorialBoxes[4])
        {
            tutorialText.text = "Each yellow square grants a point, press E to spend them";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject == tutorialBoxes[0] || collision.gameObject == tutorialBoxes[1] || collision.gameObject == tutorialBoxes[2] || collision.gameObject == tutorialBoxes[3] || collision.gameObject == tutorialBoxes[4])
        {
            tutorialText.text = "";
        }
    }
}
