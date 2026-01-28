using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool screenBlack = false;

    public float fadeDelay = 3f;

    Animator anim;

     void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void PlayGame()
    {
        StartCoroutine(Fade());

    }

    void Update()
    {
        anim.SetBool("screenBlack", screenBlack);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    IEnumerator Fade()
    {
        screenBlack = true;
        yield return new WaitForSeconds(fadeDelay);
        SceneManager.LoadScene(1);
    }
}
