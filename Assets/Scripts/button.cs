using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    private Button buttonComponent;
    // Start is called before the first frame update
    void Start()
    {
        buttonComponent = transform.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonComponent.interactable = false;
            Invoke("ClickButton", .5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonComponent.interactable = true;
            CancelInvoke();
        }
    }

    private void ClickButton()
    {
        buttonComponent.onClick.Invoke();
        Debug.Log("Button Clicked");
        CancelInvoke();
    }
}
