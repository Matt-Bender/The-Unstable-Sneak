using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 startingPos;
    [SerializeField] private bool verticalPatrol;
    [SerializeField] private bool limitPatrolLength;
    [SerializeField] private int maxPatrolLength;
    [SerializeField] private float speed;

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
        rb.velocity = transform.TransformDirection(new Vector2(0, speed));
        if (limitPatrolLength)
        {
            if (verticalPatrol)
            {
                if (transform.position.y > startingPos.y + maxPatrolLength)
                {
                    SetDirection(Vector2.down);
                }
                else if (transform.position.y < startingPos.y - maxPatrolLength)
                {
                    SetDirection(Vector2.up);
                }
            }
            else
            {
                if (transform.position.x > startingPos.x + maxPatrolLength)
                {
                    SetDirection(Vector2.left);
                }
                else if (transform.position.x < startingPos.x - maxPatrolLength)
                {
                    SetDirection(Vector2.right);
                }
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
                gameManagerScript.ReturnCheckpoint();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReverseDirection();
        //Debug.Log(gameObject.name + " Collision");
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
        //Debug.Log(gameObject.name + ": " + dir);
    }
    public Vector2 GetDirection()
    {
        return direction;
    }
}
