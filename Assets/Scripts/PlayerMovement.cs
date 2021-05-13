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
}
