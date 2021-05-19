using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3[] recentCheckpoint;
    private int checkpointNum = 0;
    private GameObject player;
    private Stealth playerStealthScript;

    private int closestNum;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < recentCheckpoint.Length; i++)
        {
            recentCheckpoint[i] = new Vector3(1000, 1000, 0);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        playerStealthScript = player.GetComponent<Stealth>();
        recentCheckpoint[checkpointNum] = player.transform.position;
        checkpointNum++;
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
        recentCheckpoint[checkpointNum] = new Vector3(checkpoint.x, checkpoint.y, -2);
        checkpointNum++;
    }

    public void ReturnCheckpoint()
    {
        
        float closestDistance = 1000;
        for(int i = 0; i < recentCheckpoint.Length; i++)
        {
            if (Vector3.Distance(recentCheckpoint[i], player.transform.position) < closestDistance)
            {
                closestNum = i;
            }
        }
        if (recentCheckpoint != null)
        {
            player.transform.position = recentCheckpoint[closestNum];

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
