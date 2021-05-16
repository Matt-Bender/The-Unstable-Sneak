using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    //The amount of speed in a given direction it takes to turn player
    [SerializeField] float rotThresh;

    private float target;
    private float goUp;
    private float goRight;

    private bool notMoving = false;
    private bool bushSpawned = false;
    private bool isStealthSkill = false;
    private GameObject tempBush;

    [SerializeField] private GameObject bush;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, target, rotSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, angle);
        CheckDirection();
    }
    private void FixedUpdate()
    {
        goUp = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        goRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.Translate(goRight, goUp, 0);
        rb.velocity = new Vector2(goRight, goUp);
        if (isStealthSkill)
        {
            if (rb.velocity.x == 0 && rb.velocity.y == 0)
            {
                if (!bushSpawned)
                {
                    Invoke("SpawnBush", 1);
                }
                notMoving = true;
                Debug.Log("Not Moving");
            }
            else
            {
                if(tempBush != null)
                {
                    Destroy(tempBush);
                }
                notMoving = false;
                bushSpawned = false;
            }
        }

    }
    private void SpawnBush()
    {
        if (notMoving && !bushSpawned)
        {
            bushSpawned = true;
            tempBush = Instantiate(bush, new Vector3(transform.position.x - 1.5f, transform.position.y - 1.5f, -1), Quaternion.Euler(0, 0, 0));
        }

    }

    private void SetRotation(int deg)
    {
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, deg));
        target = deg;
    }
    private void CheckDirection()
    {
        //45 degree angles
        if(goUp > 0 + rotThresh && goRight > 0 + rotThresh)
        {
            //NE
            SetRotation(-45);
        }
        else if(goUp > 0 + rotThresh && goRight < 0 - rotThresh)
        {
            //NW
            SetRotation(45);
        }
        else if(goUp < 0 - rotThresh && goRight > 0 + rotThresh)
        {
            //SE
            SetRotation(-135);
        }
        else if(goUp < 0 - rotThresh && goRight < 0 - rotThresh)
        {
            //SW
            SetRotation(135);
        }
        //90 degree angles
        else if(goUp > 0 + rotThresh)
        {
            //N
            SetRotation(0);
        }
        else if(goUp < 0 - rotThresh)
        {
            //S
            SetRotation(180);
        }
        else if(goRight > 0 + rotThresh)
        {
            //E
            SetRotation(-90);
        }
        else if(goRight < 0 - rotThresh)
        {
            //W
            SetRotation(90);
        }
    }

    public void IncreaseMovement()
    {
        speed += 150;
        Debug.Log("Current Speed: " + speed);
    }

    public void EnableSkillStealth()
    {
        isStealthSkill = true;
    }
}
