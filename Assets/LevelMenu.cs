using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private float Fadewait = 3f;

    public bool screenBlack = false;

    Animator anim;


    public void Start()
    {
        anim.GetComponent<Animator>();
    }

    public void Update()
    {
        //anim.SetBool("screenBlack", screenBlack);
    }
    public void OpenLevel(int levelId)
    {
        screenBlack = true;
        StartCoroutine(wait());
        SceneManager.LoadScene(levelId);

    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(Fadewait);
}


}
