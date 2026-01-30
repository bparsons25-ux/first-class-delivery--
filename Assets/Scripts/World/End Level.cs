using System.Collections;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject EndScreenCanvas;
    [SerializeField] private camMove cM;
    [SerializeField] private PlayerMovement pM;
    [SerializeField] private spawnHouses sH;
    [SerializeField] private obstacleSpawn oS;
    [SerializeField] public GameObject player;
    public GameObject  HealthBar;
    public GameObject GeneralUI;
    public GameObject distanceCount;
    public GameObject Dest;
    public GameObject Detector;
    [SerializeField] private Shoot Shoot;
    [SerializeField] private healthController Health;

    public float uiDelaywait = 1f;
    public float endgameplaywait = 1f;
    public float endlevelwiat = 3f;

    public bool swipe = false;
    public bool Uinterface = true;
    public bool delay = false;






    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Detector"))
        {
            Debug.Log("Level end Reached");
            sH.gameObject.SetActive(false);
            oS.gameObject.SetActive(false);
            StartCoroutine(WaitforUIdisplay());

        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BacktoLevel()
    {
        SceneManager.LoadScene("Main Menu"); //chnage once level select function works
    }

    IEnumerator WaitforUIdisplay()
    {
        Health.enabled = false;
        Shoot.enabled = false;
        yield return new WaitForSeconds(endgameplaywait);
        cM.enabled = false;
        Dest.gameObject.SetActive(true);



        //pM.gameObject
        Dest.gameObject.SetActive(true);
        yield return new WaitForSeconds(uiDelaywait);
        GeneralUI.gameObject.SetActive(false);
        HealthBar.gameObject.SetActive(false);
        distanceCount.gameObject.SetActive(false);
        EndScreenCanvas.SetActive(true);





    }

    IEnumerator leveldelay()
    {
        swipe = true;
        yield return new WaitForSeconds(endlevelwiat);
        delay = true;
    }
   



    public void NextLevel(int levelId)
    {
        StartCoroutine(leveldelay());

        if (delay == true)
        {
            SceneManager.LoadScene(levelId + 1);

        }

    }
}
