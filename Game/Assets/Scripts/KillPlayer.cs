using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public Transform respawnPoint;

    public GameObject rock;
    public Transform rockPoint;

    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorP2;

    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerOne"))
        {
            playerOne.transform.position = respawnPoint.position;
        }

        if (other.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwo.transform.position = respawnPoint.position;  
        }

        if (other.gameObject.CompareTag("Box"))
        {
            rock.transform.position = rockPoint.position;
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerOne"))
        {
            playerOne.transform.position = respawnPoint.position;
            _animator.SetBool("isDead", true);
        }

        if (other.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwo.transform.position = respawnPoint.position;
            _animatorP2.SetBool("isDead", true);  
        }

        if (other.gameObject.CompareTag("Box"))
        {
            rock.transform.position = rockPoint.position;
        }
        
    }



}
