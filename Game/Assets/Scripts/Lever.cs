using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool canInteract;

    public GameObject dissapearingObj;


    public KeyCode Intreact;

    //public GameObject leverRotate;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            Debug.Log("Player entered the trigger-Lever");

            //

            canInteract = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            Debug.Log("Player exited the trigger-Lever");

            //

            canInteract = false;
        }

    }

    public void Update()
    {
        //switchOff();
        if (canInteract && Input.GetKeyDown(Intreact))
        {
            toggleObj();

            //leverRotate.transform.Rotate(Vector3.forward * 100f * Time.deltaTime);
        }



    }
    private void toggleObj()
    {
        dissapearingObj.SetActive(!dissapearingObj.activeSelf);

    }




}
