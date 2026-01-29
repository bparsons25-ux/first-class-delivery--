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

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

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
