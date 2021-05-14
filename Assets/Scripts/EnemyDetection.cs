using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private GameObject wideRangeDetection;
    [SerializeField] private BoxCollider2D wideDetectionCollider;
    [SerializeField] private LayerMask obstacleLayer;
    private Transform startingWideRangeDetection;

    private EnemyMovement enemyMovementScript;
    private float rayDistance = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        wideRangeDetection = transform.Find("Wide Range Detection").gameObject;
        wideDetectionCollider = wideRangeDetection.GetComponent<BoxCollider2D>();
        enemyMovementScript = GetComponent<EnemyMovement>();

        startingWideRangeDetection = wideRangeDetection.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, enemyMovementScript.GetDirection(), rayDistance, obstacleLayer);
        Debug.DrawRay(transform.position, enemyMovementScript.GetDirection() * rayDistance, Color.green);

        if (hit.collider != null)
        {
            //Debug.Log("Raycast Hit Wall");
            wideRangeDetection.transform.localScale = new Vector3(wideRangeDetection.transform.localScale.x, hit.distance - .5f, wideRangeDetection.transform.localScale.z);
            wideRangeDetection.transform.localPosition = new Vector3(wideRangeDetection.transform.localPosition.x, wideRangeDetection.transform.localScale.y / 2 + .5f, wideRangeDetection.transform.localPosition.z);
        }
        else
        {
            //Debug.Log("Not Hitting Object");
            wideRangeDetection.transform.localScale = new Vector3(wideRangeDetection.transform.localScale.x, 4, wideRangeDetection.transform.localScale.z);
            wideRangeDetection.transform.localPosition = new Vector3(wideRangeDetection.transform.localPosition.x, wideRangeDetection.transform.localScale.y / 2 + .5f, wideRangeDetection.transform.localPosition.z);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
    }
}
