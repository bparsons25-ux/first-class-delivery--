using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    [SerializeField] private MainMenu menu;

    public void Pause()
    {
     pauseMenu.SetActive(true);
     Time.timeScale = 0f;
    }

    public void Home()
    {
        if (menu.isFinished == true)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }

        if (menu.isFinished == false)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }


    }

    public void Resume()
    {
     pauseMenu.SetActive(false);
     Time.timeScale = 1f;


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }



}
