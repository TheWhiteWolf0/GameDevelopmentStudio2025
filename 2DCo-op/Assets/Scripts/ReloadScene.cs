using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOneRespawn : MonoBehaviour
{
    //public KeyCode respawnButton;

    //public Transform respawnPoint;

    //public GameObject Player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
