using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public EnemyBehaviour enemyPrefab;
    public float timeBetweenSpawn;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;

    float timeBeforeSpawn;
    Ray spawnRay;
    float spawnRayLength;

    // Start is called before the first frame update
    void Start()
    {
        timeBeforeSpawn = timeBetweenSpawn;

        Vector3 spawnRayDirection = spawnPoint2.transform.position - spawnPoint1.transform.position;
        spawnRay = new Ray(spawnPoint1.transform.position, spawnRayDirection);
        spawnRayLength = spawnRayDirection.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeSpawn -= Time.deltaTime;

        if (timeBeforeSpawn <= 0)
        {
            // Spawn in random point in the ray
            float randomPointDistance = Random.Range(0f, spawnRayLength);
            Instantiate(enemyPrefab, spawnRay.GetPoint(randomPointDistance), transform.rotation);
            timeBeforeSpawn = timeBetweenSpawn;
        }
    }
}
