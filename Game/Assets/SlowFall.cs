using Unity.VisualScripting;
using UnityEngine;

public class SlowFall : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Gravity Settings")]
    public float normalGravity = 4f;
    public float slowFallGravity = 0.5f;

    public float normalLinearDamping = 0.05f;
    public float slowFallLinearDamping = 2f;

    [Header("FallDamage")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float slowFallStamina = 25f;
    public float maxSlowFallStamina = 25f;

    public bool isSlowFalling = false;

    public bool hitGround = false;

    [Header("Input Settings")]
    public KeyCode slowFallKey = KeyCode.DownArrow;

    [Header("Respawn")]
    public GameObject playerTwo;

    public Transform platerTwoRespawn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = normalGravity;
    }

    void Update()
    {
        //Debug.Log(rb.linearVelocityY);
        staminaSlowFall();
        FallDamage();

        // Check if player is falling
        if (rb.linearVelocity.y < 0)
        {
            if (Input.GetKey(slowFallKey) && slowFallStamina > 0)
            {
                // Apply slowfall gravity
                rb.gravityScale = slowFallGravity;
                rb.linearDamping = slowFallLinearDamping;

                //Debug.Log(rb.linearVelocityY);

                isSlowFalling = true;

            }
            else
            {
                // Back to normal gravity
                rb.gravityScale = normalGravity;
                rb.linearDamping = normalLinearDamping;

                isSlowFalling = false;
            }
        }
        else
        {
            // Reset gravity when not falling
            rb.gravityScale = normalGravity;
            isSlowFalling = false;
        }
    }

    public void FallDamage()
    {
        if (rb.linearVelocityY <= -50f)
        {
            Debug.Log("Died to fall damage");
            playerTwo.transform.position = platerTwoRespawn.position;
            
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .4f, groundLayer);
    }

    public void staminaSlowFall()
    {
        if (isSlowFalling && slowFallStamina > 0)
        {
            slowFallStamina = slowFallStamina - 10 * Time.deltaTime;
            Debug.Log( slowFallStamina);
        }

        if (isGrounded())
        {
            slowFallStamina = maxSlowFallStamina;
        }
    }
}
