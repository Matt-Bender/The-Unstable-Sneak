using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickup : MonoBehaviour
{
    private Animator sAnim;
    private GameManager gameManagerScript;
    [SerializeField] private GameObject door;
    private Door doorScript;

    private bool pickedup = false;
    // Start is called before the first frame update
    void Start()
    {
        sAnim = GetComponent<Animator>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(door == null)
        {
            Debug.Log(gameObject.name + " Missing Door Reference");
        }
        doorScript = door.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !pickedup)
        {
            gameManagerScript.SetCheckpoint(gameObject.transform.position);
            doorScript.IncreaseStarCount();
            pickedup = true;
            sAnim.SetTrigger("Death");
        }
    }

    public void EventDestroyMe()
    {
        Destroy(gameObject);
    }
}
