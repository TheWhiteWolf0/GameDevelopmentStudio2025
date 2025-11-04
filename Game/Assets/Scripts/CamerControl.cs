using System;
using UnityEngine;

public class CamerControl : MonoBehaviour
{
    public GameObject staticCam;

    public GameObject playerOneCam;

    public GameObject playerTwoCam;

    public GameObject canvasBorder;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneCam.SetActive(false);

            staticCam.SetActive(true);
            //canvasBorder.SetActive(false);

        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwoCam.SetActive(false);

            staticCam.SetActive(true);
        }

        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneCam.SetActive(true);

            staticCam.SetActive(false);

            //canvasBorder.SetActive(true);
        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerOneCam.SetActive(true);

            staticCam.SetActive(false);
            
        }

        
    }



}
