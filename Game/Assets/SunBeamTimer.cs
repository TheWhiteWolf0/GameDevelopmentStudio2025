using UnityEngine;

public class SunBeamTimer : MonoBehaviour
{
    public float timeTillDestory;
    void Update()
    {
        Destroy(gameObject, timeTillDestory);
    }
}
