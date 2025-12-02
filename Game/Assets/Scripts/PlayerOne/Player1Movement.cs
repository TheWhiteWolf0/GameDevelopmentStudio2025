using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;


public class Player1Movement : MonoBehaviour
{

    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFaceingRight = true;



    private bool isJumping;
    public int maxJumps = 2;
    private int remainingJumps;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private BoxCollider2D bc;

    // Grab/Pull mechanic
    public Transform grabDetect;
    public float rayDis;
    public Transform boxHolder;
    public Rigidbody2D rbBox;

    public bool canFlip = true;

    [SerializeField] private Animator animator;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;
        canFlip = true;
    }
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal1");
        
        if(horizontal != 0)
        {
            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }

        if (isGrounded() && !Input.GetKeyDown(KeyCode.W))
        {
            isJumping = false;
            remainingJumps = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded() || (isJumping && remainingJumps > 0)) 
            {
                isJumping = true;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                remainingJumps--;

            }
    
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        grabPull();

        if (canFlip == true)
        {
            flip();
            speed = 8;
        }

        if (canFlip == false)
        {
            speed = 2; 
        }


        


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }




    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        if (isFaceingRight && horizontal < 0f || !isFaceingRight && horizontal > 0f)
        {
            isFaceingRight = !isFaceingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

    private void grabPull()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDis);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                rbBox = grabCheck.collider.gameObject.GetComponent<Rigidbody2D>();

                bc.enabled = true;

                rbBox.bodyType = RigidbodyType2D.Kinematic;

                //

                canFlip = false;
            }

            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                rbBox = grabCheck.collider.gameObject.GetComponent<Rigidbody2D>();
                rbBox.bodyType = RigidbodyType2D.Dynamic;

                bc.enabled = false;

                //

                canFlip = true;
                
            }
        }
        
    }

    public void sunBridge()
    {
        
    }

}
