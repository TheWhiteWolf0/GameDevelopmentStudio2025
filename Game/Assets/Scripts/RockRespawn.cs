using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRespawn : MonoBehaviour
{
    public GameObject Rock;
    public Transform rockPoint;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerOne"))
        {
            Rock.transform.position = rockPoint.position;
        }


    }



}