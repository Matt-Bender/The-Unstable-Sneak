using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private GameObject perimeter1;
    [SerializeField] private GameObject perimeter2;

    [SerializeField] private bool genLevel;
    // Start is called before the first frame update
    void Start()
    {
        if(genLevel)
        GenLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenLevel()
    {
        for (float y = perimeter1.transform.position.y; y > perimeter2.transform.position.y; y -= 10)
        {
            for (float x = perimeter1.transform.position.x; x < perimeter2.transform.position.x; x += 10)
            {
                //0-3
                int randNum = Random.Range(0, 4);
                Instantiate(blocks[randNum], new Vector2(x, y), Quaternion.identity);
            }
        }

        
    }
}
