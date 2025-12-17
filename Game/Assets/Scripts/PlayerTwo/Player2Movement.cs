using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;


public class Player2Movement : MonoBehaviour
{

    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFaceingRight = true;



    private bool isJumping;
    public int maxJumps = 3;
    private int remainingJumps;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    [SerializeField] private Animator _animator;

    AudioManager audioManager;

    public AudioSource walk;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            walk.enabled = true;
        }

        else
        {
            walk.enabled = false;
        }





        horizontal = Input.GetAxisRaw("Horizontal2");

        if(horizontal != 0)
        {
            _animator.SetBool("isRunning", true);
        }

        else
        {
            _animator.SetBool("isRunning", false);
        }

        if (rb.linearVelocityY < 0)
        {
            _animator.SetBool("isFloating", true);
            _animator.SetBool("isRunning", false);
        }

        else
        {
            _animator.SetBool("isFloating", false); 
        }



        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded() || (isJumping && remainingJumps > 0))
            {
                audioManager.PlayerSFX(audioManager.jump);
                isJumping = true;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                remainingJumps--;
            }

        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.linearVelocity.y > 0f)
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

    public void thing6767()
    {
        _animator.SetBool("isDead", false);
    }

}