using System.Collections;
using System.Threading.Tasks;
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



    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal1");

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

        flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        
        //rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
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

}
