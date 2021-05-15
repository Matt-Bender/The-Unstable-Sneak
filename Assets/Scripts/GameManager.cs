using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector3 recentCheckpoint;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        recentCheckpoint = player.transform.position;
        //if (recentCheckpoint != null)
        //{
        //    player.transform.position = recentCheckpoint;
        //}
        
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
        recentCheckpoint = checkpoint;
    }

    public void ReturnCheckpoint()
    {
        if (recentCheckpoint != null)
        {
            player.transform.position = recentCheckpoint;
        }
        
    }
}
