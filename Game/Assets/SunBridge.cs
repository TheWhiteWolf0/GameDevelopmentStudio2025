using UnityEngine;

public class SunBridge : MonoBehaviour
{
    public GameObject bridgePrefab;   // Assign in Inspector
    public Transform placementPoint;  // Where the bridge should appear

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlaceBridge();
        }
    }

    void PlaceBridge()
    {
        Instantiate(bridgePrefab, placementPoint.position, Quaternion.identity);
    }
}
