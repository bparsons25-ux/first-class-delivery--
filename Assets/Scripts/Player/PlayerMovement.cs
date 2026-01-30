using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    public GameObject DeathscreenCanvas;

    public WaitForSeconds deathWait;

    [SerializeField] private Shoot Shoot;

    public float downTimer = 0;
    public float downShootDelay = 0.2f;

    public float speedboosttime = 30f;
    public float shieldboosttime = 30f;


    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public AudioClip flying; // done
    public AudioClip shoot; // done
    public AudioClip damage; // done
    public AudioClip collect;
    public AudioClip complete;
    public AudioClip righthouse;
    public AudioClip wronghouse;
    public AudioClip chimmney;

    [SerializeField] private camMove cm;
    [SerializeField] private healthController hc;

    Renderer ren;

    [SerializeField] AudioSource playersfx; 



    public bool isThrow1 = false;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playersfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");


        playerDirection = new Vector2(0, directionY).normalized;

        Flip();

        anim.SetBool("isThrow1", isThrow1);   
 
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    public void Flip()
    {
        if (Input.GetMouseButtonDown(0) && Shoot.allowShooting == true && Time.time >= downTimer)
        {
            shootaudio();
            transform.Rotate(0, 0, -90);
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            downTimer = Time.time + downShootDelay;
            Debug.Log("Left click - downwards shoot");
            transform.Rotate(0, 0, 90);
            Shoot.LoseAmmo();
            isThrow1 = true;

        }

        else { isThrow1 = false;  }
    }

    public void shootaudio()
    {
        playersfx.PlayOneShot(shoot);
    }

    public void damageaudio()
    {
        playersfx.PlayOneShot(damage);
    }


    public void completeaudio()
    {
        playersfx.PlayOneShot(complete);
    }


    public void righthouseaudio()
    {
        playersfx.PlayOneShot(righthouse);
    }

    public void wronghouseaudio()
    {
        playersfx.PlayOneShot(wronghouse);
    }


    public void chimmneyaudio()
    {
        playersfx.PlayOneShot(chimmney);
    }

    public void collectaudio()
    {
        playersfx.PlayOneShot(collect);
    }

    public void shield()
    {
        StartCoroutine(shieldpowerup());
    }



    public void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
        DeathscreenCanvas.SetActive(true);
        Debug.Log("Dead!");
        
    
    }

    IEnumerator speedpowerup()
    {
        //cm.cameraSpeed * 1.5f;
        yield return new WaitForSeconds(speedboosttime);
        //cm.cameraSpeed / 1.5;
    }

    IEnumerator shieldpowerup()
    {
        hc.allowDamage = false;
        ren.GetComponent<SpriteRenderer>();
        ren.material.color = Color.blue;
        yield return new WaitForSeconds(shieldboosttime);
        ren.material.color = Color.white;
        hc.allowDamage = true;

    }



}
