using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickup : MonoBehaviour
{
    private Animator sAnim;
    private GameManager gameManagerScript;

    private bool pickedup = false;
    // Start is called before the first frame update
    void Start()
    {
        sAnim = GetComponent<Animator>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !pickedup)
        {
            pickedup = true;
            gameManagerScript.IncreaseStarCount();
            sAnim.SetTrigger("Death");
        }
    }

    public void EventDestroyMe()
    {
        Destroy(gameObject);
    }
}
