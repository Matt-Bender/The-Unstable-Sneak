using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingStarsDisplay : MonoBehaviour
{
    private Door doorScript;
    [SerializeField] private TextMeshProUGUI tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        doorScript = GetComponent<Door>();
        tutorialText = GameObject.Find("Canvas").GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int starCount = doorScript.GetStarCount();
            tutorialText.text = "You need " + (3 - starCount) + " more Stars to unlock";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tutorialText.text = "";
        }
    }
}
