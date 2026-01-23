using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;

     private void Update()
    {
        transform.position += new Vector3(-enemySpeed * Time.deltaTime, 0, 0);
    }

}
