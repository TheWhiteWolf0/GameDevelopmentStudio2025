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
    [SerializeField] public LayerMask groundLayer;
    public float slowFallStamina = 0f;
    public float maxSlowFallStamina = 35f;



    [Header("Input Settings")]
    public KeyCode slowFallKey = KeyCode.DownArrow;

    [Header("SlowFallBar")]

    //[Range(0, 4000)]
    //static public float stamina;
    //public float maxStamina = 2000;

    public RectTransform uiBar;

    float barWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = normalGravity;

        //slowfall stamina
        barWidth = uiBar.anchorMax.x;
        slowFallStamina = maxSlowFallStamina;
    }

    void Update()
    {
        


        // Check if player is falling
        if (rb.linearVelocity.y < 0)
        {
            if (Input.GetKey(slowFallKey) && slowFallStamina > 0)
            {
                slowFallStamina -= 3 * Time.deltaTime;

                // Apply slowfall gravity
                rb.gravityScale = slowFallGravity;
                rb.linearDamping = slowFallLinearDamping;

                if(slowFallStamina <= 0)
                {
                    rb.gravityScale = normalGravity;
                    rb.linearDamping = normalLinearDamping;  
                }
            }


        }
        else
        {
            // Reset gravity when not falling
            rb.gravityScale = normalGravity;
            rb.linearDamping = normalLinearDamping;
            //slowFallStamina = maxSlowFallStamina;
            slowFallStamina += 10 * Time.deltaTime;

        }

        //Slowfall Stamina
        
        slowFallStamina = ((slowFallStamina > maxSlowFallStamina) ? maxSlowFallStamina : (slowFallStamina < 0) ? 0 : slowFallStamina);

        float x = ((slowFallStamina * (100f / maxSlowFallStamina)) * (1f / barWidth)) / 100f;

        uiBar.anchorMax = new Vector2(x, uiBar.anchorMax.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .5f, groundLayer);
    }
}
