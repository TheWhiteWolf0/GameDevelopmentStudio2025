using UnityEngine;

public class FlowerComboLock : MonoBehaviour
{
    private bool canInteract;

    public int flowerCount = 3;

    public GameObject dissapearingObj;
    public GameObject flower1;


    public KeyCode Intreact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("PlayerOne") || collision.gameObject.CompareTag("PlayerTwo"))
        {
            Debug.Log("Player entered the trigger-Lever");

            //

            canInteract = true;

        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            Debug.Log("Player exited the trigger-Lever");

            //

            canInteract = false;
        }

    }

    public void Update()
    {
        if (canInteract && Input.GetKeyDown(Intreact) && flowerCount > 0)
        {
            toggleObj();

        }

        else
        {
            
        }

    }
    private void toggleObj()
    {
        dissapearingObj.SetActive(!dissapearingObj.activeSelf);
        flower1.SetActive(!flower1.activeSelf);
        flowerCount = flowerCount - 1;
        Debug.Log(flowerCount);
    }

}
