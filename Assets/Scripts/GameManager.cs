using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector3 recentCheckpoint;
    private GameObject player;
    private Stealth playerStealthScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStealthScript = player.GetComponent<Stealth>();
        recentCheckpoint = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void SetCheckpoint(Vector3 checkpoint)
    {
        recentCheckpoint = new Vector3(checkpoint.x, checkpoint.y, -2);
    }

    public void ReturnCheckpoint()
    {
        if (recentCheckpoint != null)
        {
            player.transform.position = recentCheckpoint;

            //Gives player brief immunity after respawning
            playerStealthScript.SetIsStealthed(true);
            Invoke("TurnOffPlayerStealth", 2);
        }
        
    }

    private void TurnOffPlayerStealth()
    {
        playerStealthScript.SetIsStealthed(false);
    }

    public void GoPlayGame()
    {
        SceneManager.LoadScene("Play");
    }

    public void GoCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
