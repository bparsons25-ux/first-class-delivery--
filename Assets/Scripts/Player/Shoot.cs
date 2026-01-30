using UnityEngine;
using TMPro;



public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public float forwardtimer = 0;
    public float shootforwardDelay = 0.2f;

    public bool allowShooting = true;
    public int currentAmmo = 30;
    public TextMeshProUGUI ammoText;

    public GameObject Player;

    [SerializeField] PlayerMovement pm;

    public bool isThrow = false;
    Animator anim;



    private void Start()
    {
        ammoText.text = "Ammo:" + currentAmmo.ToString();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

        if (allowShooting == true) // if player can shoot they will shoot
        {
            if (Input.GetMouseButtonDown(1) && Time.time >= forwardtimer)
            {
                pm.shootaudio();
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation); // spawns 
                forwardtimer = Time.time + shootforwardDelay;
                Debug.Log("Right click - Fowards Shoot");
                LoseAmmo();
                isThrow = true;

            }


            else { isThrow = false; }

        }



        anim.SetBool("isThrow", isThrow);




    }




    public void LoseAmmo()
    {
        currentAmmo -= 1;
        ammoText.text = "Ammo:" + currentAmmo.ToString();
        if (currentAmmo < 1)
        {
            allowShooting = false;
            Debug.Log("No Ammo!!!");
        }
    }

    public void GainAmmo()
    {
        currentAmmo += 5;
        ammoText.text = "Ammo:" + currentAmmo.ToString();
        Debug.Log("ammo pick up");
        if (currentAmmo > 1)
        {
            allowShooting = true;

        }
    }


}
