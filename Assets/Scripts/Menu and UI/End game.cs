using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{

    [SerializeField] private MainMenu menu;
    MainMenu MM;

    public void Start()
    {
        MM = GetComponent<MainMenu>();
    }
    public void Home()
    {
        MM.isFinished = true;
        SceneManager.LoadScene(0);

    }

    public void levelSelect()
    {
        MM.isFinished = true;
        SceneManager.LoadScene(1);

    }

    public void secretlevel()
    {
        menu.isFinished = true;
        // SceneManager.Loadscene(secret scene);
    }



}
