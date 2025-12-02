using UnityEngine;
using UnityEngine.UI; 
using TMPro;          

public class TextActivation : MonoBehaviour
{
    public GameObject textObject; 

    void Start()
    {
        // Hide text at start
        textObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo")) 
        {
            textObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
        {
            textObject.SetActive(false); 
        }
    }
}