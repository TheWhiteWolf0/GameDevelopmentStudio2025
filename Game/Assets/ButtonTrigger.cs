using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject platform;


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
}
