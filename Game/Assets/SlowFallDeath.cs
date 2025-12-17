using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class SlowFallDeath : MonoBehaviour
{
    public Rigidbody2D player2SlowFall;

    public GameObject PlayerTwo;
    public Transform respawnPoint;

    public float fallDamageThing;


    [SerializeField] private Animator _animator;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTwo") && player2SlowFall.linearVelocityY < fallDamageThing)
        {
            _animator.SetBool("isDead", true);
            //Debug.Log("P2 fall Damage");
            PlayerTwo.transform.position = respawnPoint.position;
           //Debug.Log(player2SlowFall.linearVelocityY);

        }
    }
}
