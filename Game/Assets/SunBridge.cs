using UnityEngine;

public class SunBridge : MonoBehaviour
{
    public GameObject bridgePrefab;   // Assign in Inspector
    public Transform placementPoint;  // Where the bridge should appear

    public int bridgeCount = 2;

    void Update()
    {
        if (bridgeCount > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            PlaceBridge();
        }
    }

    void PlaceBridge()
    {
        Instantiate(bridgePrefab, placementPoint.position, Quaternion.identity);
        bridgeCount--;
    }
}
