using Unity.VisualScripting;
using UnityEngine;

public class JointCamerControl : MonoBehaviour
{
    public GameObject staticCam;

    public GameObject playerOneCam;
    public GameObject playerTwoCam;

    public GameObject canvasBorder;


    public bool playerOneIn = false;
    public bool playerTwoIn = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneIn = true;
            Debug.Log("PlayerOneIn is true");

        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwoIn = true;
            Debug.Log("PlayerTwoIn is true");
        }
    }




    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerOneIn = false;
            Debug.Log("PlayerOneIn is false");
            staticCam.SetActive(false);
            canvasBorder.SetActive(true);
            playerOneCam.SetActive(true);

        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerTwoIn = false;
            Debug.Log("PlayerTwoIn is false");
            staticCam.SetActive(false);
            canvasBorder.SetActive(true);
            playerTwoCam.SetActive(true);
        }
    }

    void Update()
    {
        toggleStacticCamOn();
        //toggleStacticCamOff();
    }

    private void toggleStacticCamOn()
    {
        if (playerOneIn && playerTwoIn)
        {
            Debug.Log("H2");
            playerOneCam.SetActive(false);
            playerTwoCam.SetActive(false);

            staticCam.SetActive(true);

            canvasBorder.SetActive(false);
        }
    }
    
    private void toggleStacticCamOff()
    {
        if (!playerOneIn && !playerTwoIn)
        {
             Debug.Log("H2");
            playerOneCam.SetActive(true);
            playerTwoCam.SetActive(true);

            staticCam.SetActive(false);

            canvasBorder.SetActive(true);
        }
        
    }



}
