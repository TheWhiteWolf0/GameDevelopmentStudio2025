using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;

public class SunBridge : MonoBehaviour
{
    public GameObject bridgePrefab;   // Assign in Inspector
    public Transform placementPoint;  // Where the bridge should appear


    public int bridgeCount = 2;

    public float timeLeft = 10f;

    // Display/HUD
    public TextMeshProUGUI sunCount;
    public GameObject text;

    void Update()
    {
        //sunCount.SetText(bridgeCount.ToString());
        

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
}
