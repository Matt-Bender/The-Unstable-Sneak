using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickup : MonoBehaviour
{
    private Animator sAnim;
    // Start is called before the first frame update
    void Start()
    {
        sAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sAnim.SetTrigger("Death");
        }
    }

    public void EventDestroyMe()
    {
        Destroy(gameObject);
    }
}
