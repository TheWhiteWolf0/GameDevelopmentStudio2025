using System;
using UnityEngine;

public class CamerControl : MonoBehaviour
{
    public GameObject staticCam;

    public GameObject playerOneCam;

    public GameObject canvasBorder;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneCam.SetActive(false);

            staticCam.SetActive(true);
            //canvasBorder.SetActive(false);

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
    }



}
