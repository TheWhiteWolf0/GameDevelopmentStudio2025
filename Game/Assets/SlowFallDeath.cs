using UnityEditor.Callbacks;
using UnityEngine;

public class SlowFallDeath : MonoBehaviour
{
    public Rigidbody2D player2SlowFall;

    public GameObject PlayerTwo;
    public Transform respawnPoint;

    public float fallDamageThing;

    void Start()
    {
        //player2SlowFall = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTwo") && player2SlowFall.linearVelocityY <= fallDamageThing)
        {
           Debug.Log("P2 fall Damage");
           PlayerTwo.transform.position = respawnPoint.position; 
           Debug.Log(player2SlowFall.linearVelocityY);

        }
    }
}
