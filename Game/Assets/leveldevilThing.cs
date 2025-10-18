using UnityEngine;

public class leveldevilThing : MonoBehaviour
{
    public bool canFloorMove;

    public GameObject slidingFloor;
    public GameObject tarPosition;

    public Vector2 thingThing;
    //public GameObject targetPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            Debug.Log("Player entered the trigger-sliding floor");

            //

            canFloorMove = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            Debug.Log("Player exited the trigger-sliding floor");

            //

            canFloorMove = false;
        }

    }



    //public GameObject targetObject;
    public float smoothingSpeed = 5f;

    void Update()
    {

        if (canFloorMove)
        {
            Vector2 startPosition = slidingFloor.transform.position;
            Vector2 endPosition = tarPosition.transform.position;
            transform.position = Vector2.Lerp(startPosition, endPosition, smoothingSpeed * Time.deltaTime);
            //thing();
        }
    }

    private void thing()
    {
        //thingThing = new Vector2();
        Vector2 startPosition = slidingFloor.transform.position;
        //Vector2 thingEnd = thingThing;
        transform.position = Vector2.Lerp(startPosition, thingThing, smoothingSpeed * Time.deltaTime);
    }
}
