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

    private Rigidbody2D player2SlowFall;

    void Start()
    {
        player2SlowFall = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
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



}
