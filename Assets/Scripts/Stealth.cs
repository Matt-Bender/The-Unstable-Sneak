using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth : MonoBehaviour
{
    [SerializeField] private bool isStealthed;
    private Renderer triangle;
    [SerializeField] private Material playerMat;
    [SerializeField] private Material stealthMat;
    // Start is called before the first frame update
    void Start()
    {
        triangle = transform.Find("Triangle").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            isStealthed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            isStealthed = false;
        }
    }
    public bool GetIsStealthed()
    {
        return isStealthed;
    }

    public void SetIsStealthed(bool stealth)
    {
        if (stealth)
        {
            triangle.material = stealthMat;
        }
        else
        {
            triangle.material = playerMat;
        }
        isStealthed = stealth;
    }
}
