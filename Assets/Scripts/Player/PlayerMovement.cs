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

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public bool isThrow = false;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");


        playerDirection = new Vector2(0, directionY).normalized;

        Flip();

        anim.SetBool("isThrow", isThrow);   
 
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    public void Flip()
    {
        if (Input.GetMouseButtonDown(0) && Shoot.allowShooting == true)
        {
            transform.Rotate(0, 0, -90);
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            downTimer = Time.time + downShootDelay;
            Debug.Log("Left click - downwards shoot");
            transform.Rotate(0, 0, 90);
            Shoot.LoseAmmo();
        }
    }



    public void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
        DeathscreenCanvas.SetActive(true);
        Debug.Log("Dead!");
        
    
    }


}
