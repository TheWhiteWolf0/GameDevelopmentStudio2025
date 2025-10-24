using Unity.VisualScripting;
using UnityEngine;

public class TestPush : MonoBehaviour
{
    [SerializeField] private Transform PushCheck;
    [SerializeField] private LayerMask pushLayer;

    [SerializeField] private GameObject pushBox;

    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (canPush())
            {
                Debug.Log("Is Pushing");
                //pushBox.transform.position = PushCheck.transform.position;
                //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                Vector2 startPosition = PushCheck.transform.position;
                Vector2 endPosition = pushBox.transform.position;
                transform.position = Vector2.Lerp(startPosition, endPosition, 100 * Time.deltaTime);
            }

            else
            {
                //rb.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    private bool canPush()
    {
        Debug.Log("Player exited the Push-Trigger");
        return Physics2D.OverlapCircle(PushCheck.position, 1f, pushLayer);
    }
    


}
  
