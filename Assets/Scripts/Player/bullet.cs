using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float shootingSpeed;
    private Rigidbody2D rb;

    public GameObject Enemy;

    public Collider2D DeliverySpace;

    public GameObject Chimney;

    public GameObject DeliveryZone;





    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * shootingSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Delivery"))
        {
            Score.instance.AddpointNormal();
            Score.instance.PackageDeliverSucess();
            Debug.Log("Delivered");
            Destroy(gameObject);
            Destroy(DeliveryZone);


            
        }

        if (collision.CompareTag("Obstacle"))
        {
            Score.instance.addsmmallpoints();
            Debug.Log("Lost!");
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

        if (collision.CompareTag("Chimney"))
        {
            Score.instance.AddpointBonus();
            Score.instance.PackageDeliverSucess();
            Debug.Log("Chimney");
            Destroy(gameObject);
            Destroy(Chimney);

        }
        
       
    }




}
