using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float goUp = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float goRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.Translate(goRight, goUp, 0);
        rb.velocity = new Vector2(goRight, goUp);
        if (goUp > 1)
        {
            //if(transform.rotation.z > )
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (goUp < -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else if (goRight > 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
        else if (goRight < -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, Input.mousePosition.z));
        //Vector3 mousePos = Input.mousePosition;
        //transform.LookAt(mousePos);
        //Debug.Log("Vertical: " + goUp + "Horizontal: " + goRight);
    }
}
