using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject deathScreenCanvas; 

    public void ShowDeathScreen()
    {
        deathScreenCanvas.SetActive(true);

        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 0f;
        Application.Quit();
        Debug.Log("Quit Pressed");
    }

}
