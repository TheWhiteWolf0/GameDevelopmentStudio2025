using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayIntro()
    {
        SceneManager.LoadSceneAsync(1);
    }



    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }



    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenue()
    {
        SceneManager.LoadScene(0);
    }

}
