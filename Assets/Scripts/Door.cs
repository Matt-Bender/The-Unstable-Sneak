using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject[] stars;
    private int starCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseStarCount()
    {
        starCount++;
        if (starCount >= 3)
        {
            Debug.Log("You Win");
            Destroy(gameObject);
        }
    }
}
