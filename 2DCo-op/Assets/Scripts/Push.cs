using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Push : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canPush;
    public KeyCode Interact;



    public float thrust = 20f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTwo") || collision.gameObject.CompareTag("PlayerOne"))
        {
            Debug.Log("Player exited the trigger-pushCube");

            //

            canPush = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTwo") || collision.gameObject.CompareTag("PlayerOne"))
        {
            Debug.Log("Player exited the trigger-pushCube");

            //

            canPush = false;


        }
    }

    private void isPushingLeft()
    {
        if (canPush && Input.GetKey(Interact))
        {
            //rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            //rb.constraints = RigidbodyConstraints2D.FreezeRotation;




            //

            //rb.AddForce(Vector2.right * thrust);
        }

        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
           // rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }







    // Update is called once per frame
    void Update()
    {
        isPushingLeft();


        //rb.AddForce(Vector2.right * thrust);

        //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
