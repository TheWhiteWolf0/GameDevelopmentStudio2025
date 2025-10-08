using UnityEngine;

public class CollisionThing : MonoBehaviour
{
    public GameObject dissapearingObj;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            Debug.Log("Player entered the trigger");

            //

            dissapearingObj.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))

        Debug.Log("Player has left the trigger");

        //

        dissapearingObj.SetActive(true);
    }




}
