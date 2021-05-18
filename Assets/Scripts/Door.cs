using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject stars;
    private int starCount = 0;
    [SerializeField] private bool oneStar = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stars!= null)
        {
            
        }
    }
    public void IncreaseStarCount()
    {
        if (oneStar)
        {
            Destroy(gameObject);
        }
        starCount++;
        if (starCount >= 3)
        {
            Debug.Log("You Win");
            Destroy(gameObject);
        }
    }

    public int GetStarCount()
    {
        return starCount;
    }
}
