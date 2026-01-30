using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{

    public void Home()
    {

        SceneManager.LoadScene(0);

    }

    public void levelSelect()
    {

        SceneManager.LoadScene(1);

    }

    public void secretlevel()
    {
     
        // SceneManager.Loadscene(secret scene);
    }



}
