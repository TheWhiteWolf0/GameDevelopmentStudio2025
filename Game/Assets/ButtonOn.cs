using UnityEngine;

public class ButtonOn : MonoBehaviour
{
    public GameObject platform;

/*
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ButtonTag1"))
        {
            //platform.SetActive(!platform.activeSelf);
            platform.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ButtonTag1"))
        {
            platform.SetActive(false);
        }
    }

*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ButtonTag1"))
        {
            //platform.SetActive(!platform.activeSelf);
            platform.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ButtonTag1"))
        {
            platform.SetActive(true);
        }
    }


}
