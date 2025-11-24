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

    [Header("Input Settings")]
    public KeyCode slowFallKey = KeyCode.DownArrow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = normalGravity;
    }

    void Update()
    {
        FallDamage();

        //Debug.Log(rb.linearVelocityY);

        // Check if player is falling
        if (rb.linearVelocity.y < 0)
        {
            if (Input.GetKey(slowFallKey))
            {
                // Apply slowfall gravity
                rb.gravityScale = slowFallGravity;
                rb.linearDamping = slowFallLinearDamping;

            }
            else
            {
                // Back to normal gravity
                rb.gravityScale = normalGravity;
                rb.linearDamping = normalLinearDamping;
            }
        }
        else
        {
            // Reset gravity when not falling
            rb.gravityScale = normalGravity;
        }
    }

    public void FallDamage()
    {
        if (rb.linearVelocityY <= -50f)
        {
            Debug.Log("Died to fall damage");
            
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("fallDamage"))
        //{
            //Debug.Log("Collision with fallGroundDamage");
        //}
        
    //}
}
