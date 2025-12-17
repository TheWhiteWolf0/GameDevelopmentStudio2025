using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCut : MonoBehaviour
{
    public bool P1In = false;
    public bool P2In = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.CompareTag("PlayerOne"))
        {
            P1In = true;
        }

        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            P2In = true;
        }
    }

    void Update()
    {
        if(P1In && P2In)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }

}
