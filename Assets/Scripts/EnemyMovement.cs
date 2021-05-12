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
    private Vector2 direction;

    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
        if (!verticalPatrol)
        {
            SetDirection(Vector2.right);
        }
        else
        {
            SetDirection(Vector2.up);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        playerStealthScript = player.GetComponent<Stealth>();

        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(new Vector2(0, 3));
        if (verticalPatrol)
        {
            if (transform.position.y > startingPos.y + 5)
            {
                SetDirection(Vector2.down);
            }
            else if (transform.position.y < startingPos.y - 5)
            {
                SetDirection(Vector2.up);
            }
        }
        else
        {
            if (transform.position.x > startingPos.x + 5)
            {
                SetDirection(Vector2.left);
            }
            else if (transform.position.x < startingPos.x - 5)
            {
                SetDirection(Vector2.right);
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
                gameManagerScript.RestartScene();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReverseDirection();
    }
    private void ReverseDirection()
    {
        if (verticalPatrol)
        {
            if(direction == Vector2.up)
            {
                SetDirection(Vector2.down);
            }
            else if(direction == Vector2.down)
            {
                SetDirection(Vector2.up);
            }
        }
        else
        {
            if (direction == Vector2.right)
            {
                SetDirection(Vector2.left);
            }
            else if (direction == Vector2.left)
            {
                SetDirection(Vector2.right);
            }
        }
    }
    private void SetDirection(Vector2 dir)
    {
        if(dir == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if(dir == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else if(dir == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
        else if(dir == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        direction = dir;
    }
    public Vector2 GetDirection()
    {
        return direction;
    }
}
