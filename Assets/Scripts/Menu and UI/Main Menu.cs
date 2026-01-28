using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool screenBlack = false;

    public float fadeDelay = 3f;
    
    public void PlayGame()
    {


    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(fadeDelay);
        SceneManager.LoadScene(1);
    }
}
