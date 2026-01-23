using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] GameObject DeathScreen;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Levelselect()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        
    }
}
