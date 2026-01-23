using UnityEngine;

public class spawnHouses : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float timeBetweenSpawn;
    private float spawnTime;
    

    private void Update()
    {
        if (Time.time > spawnTime) 
        {

            spawnTime = Time.time + timeBetweenSpawn;

            int selection = Random.Range (0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection], transform.position, transform.rotation);
        }
    }

}
