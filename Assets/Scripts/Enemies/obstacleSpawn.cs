using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public GameObject Enemy ;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public float timeBetweenSpawn;
    private float spawnTime;

    private void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(Enemy, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }
}
