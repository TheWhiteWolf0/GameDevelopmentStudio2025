using System;
using UnityEngine;

public class CamerControl : MonoBehaviour
{
    public GameObject staticCamOne;
    public GameObject staticCamTwo;


    public GameObject playerOneCam;

    public GameObject playerTwoCam;

    public GameObject canvasBorder;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneCam.SetActive(false);

            staticCamOne.SetActive(true);
            //canvasBorder.SetActive(false);

        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwoCam.SetActive(false);

            staticCamTwo.SetActive(true);
        }

        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneCam.SetActive(true);

            staticCamOne.SetActive(false);

            //canvasBorder.SetActive(true);
        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            Debug.Log("Help jointcamstactic");
            playerTwoCam.SetActive(true);

            staticCamTwo.SetActive(false);
            
        }   
    }
}
