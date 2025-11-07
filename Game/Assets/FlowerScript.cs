using Unity.VisualScripting;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    private bool canInteract;

    public int flowerCount = 3;

    public GameObject dissapearingObj;
    public GameObject flower;


    public KeyCode Intreact;

    //public GameObject leverRotate;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("PlayerOne"))
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
        //switchOff();
        if (canInteract && Input.GetKeyDown(Intreact) && flowerCount > 0)
        {
            toggleObj();

            //leverRotate.transform.Rotate(Vector3.forward * 100f * Time.deltaTime);
        }

        else
        {
            Debug.Log("Out of seeds");
        }



    }
    private void toggleObj()
    {
        dissapearingObj.SetActive(!dissapearingObj.activeSelf);
        flower.SetActive(!flower.activeSelf);
        flowerCount = flowerCount - 1;
        Debug.Log(flowerCount);

    }




}
