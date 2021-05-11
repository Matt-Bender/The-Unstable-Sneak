using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 startingPos;
    [SerializeField] private bool verticalPatrol;

    private GameObject player;
    private Stealth playerStealthScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
        if (!verticalPatrol)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }

        player = GameObject.FindGameObjectWithTag("Player");
        playerStealthScript = player.GetComponent<Stealth>();
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(new Vector2(0, 3));
        if (verticalPatrol)
        {
            if (transform.position.y > startingPos.y + 5)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            }
            else if (transform.position.y < startingPos.y - 5)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
        else
        {
            if (transform.position.x > startingPos.x + 5)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            }
            else if (transform.position.x < startingPos.x - 5)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerStealthScript.GetIsStealthed())
            {

            }
            else
            {
                Debug.Log("You Lose");
            }
        }
    }
}
