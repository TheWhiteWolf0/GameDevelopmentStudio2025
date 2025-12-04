using UnityEngine;

public class GrabControl : MonoBehaviour
{
   //public LayerMask pushLayer;
    public Transform grabDetect;
    //public Transform grabCheck;
    public float rayDis;
    public Transform boxHolder;

    public Rigidbody2D rb;

    //Hmmm
    public bool canFlip;
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDis);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                rb = grabCheck.collider.gameObject.GetComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Kinematic;

                //

                canFlip = false;
            }

            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                rb = grabCheck.collider.gameObject.GetComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Dynamic;

                //

                canFlip = true;
                
            }
        }
    }
}
