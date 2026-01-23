using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Houses; 
    public GameObject Bullets;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject  )
        {
            //Then we use this method to destroy it
            Destroy(collision.gameObject);
        }
    }

}
