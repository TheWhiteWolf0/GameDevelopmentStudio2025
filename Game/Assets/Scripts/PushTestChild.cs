using UnityEngine;

public class PushTestChild : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject childObject;

    [SerializeField] private Transform PushCheck;
    [SerializeField] private LayerMask pushLayer;



    [Header("Pull Settings")]
    [SerializeField] private float pullForce = 10f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private LayerMask validLayers;

    void Start()
    {
        // Make childObject a child of parentObject while preserving world position
        //childObject.transform.SetParent(parentObject.transform, true);
        //childObject.transform.parent = parentObject.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canPush())
            {
                Debug.Log("Yippie");
                childObject.transform.SetParent(parentObject.transform, worldPositionStays: true);
            }
        }

        else
        {
            
        }
    }



    private bool canPush()
    {
        Debug.Log("Player exited the Push-Trigger");
        return Physics2D.OverlapCircle(PushCheck.position, 0.2f, pushLayer);
    }

    private void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, maxDistance, validLayers);
        
        foreach (Collider2D hit in hits)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            
            if (rb != null)
            {
                Vector2 direction = transform.position - hit.transform.position;
                float distance = direction.magnitude;
                
                // Calculate force based on distance (stronger when closer)
                float forceMultiplier = Mathf.Clamp01(1 - (distance / maxDistance));
                float appliedForce = pullForce * forceMultiplier;
                
                // Apply the force smoothly
                rb.AddForce(direction.normalized * appliedForce, ForceMode2D.Force);
            }
        }
    }





    
}
