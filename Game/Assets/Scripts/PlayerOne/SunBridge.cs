using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;

public class SunBridge : MonoBehaviour
{
    public GameObject bridgePrefab;   // Assign in Inspector
    public Transform placementPoint;  // Where the bridge is placed

    public GameObject sun1;
    public GameObject sun2;

    public int bridgeCount = 2;

    public float timeLeft = 15f;

    // Display/HUD
    public TextMeshProUGUI sunCount;
    public GameObject text;

    void Update()
    {
        //sunCount.SetText(bridgeCount.ToString());

        HUD(bridgeCount);
        

        if (bridgeCount > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            PlaceBridge();
        }

        if (bridgeCount <= 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                bridgeCount = 2;
                timeLeft = 10f;
            }
        }
    }

    void PlaceBridge()
    {
        Instantiate(bridgePrefab, placementPoint.position, Quaternion.identity);
        bridgeCount--;
    }

    private void HUD(int bridgs)
    {
        if(bridgs == 2)
        {
            sun1.SetActive(true);
            sun2.SetActive(true);
        }

        if(bridgs == 1)
        {
            sun1.SetActive(true);
            sun2.SetActive(false); 
        }

        if(bridgs == 0)
        {
            sun1.SetActive(false);
            sun2.SetActive(false);
            
        }
        
    }
}
