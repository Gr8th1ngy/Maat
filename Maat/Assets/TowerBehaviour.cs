using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public RallyPointBehaviour rallyPoint;
    
    public GameObject soldierPrefab;
    public float spawnRate;
    public Transform spawnPoint;

    float timeBetweenSpawn;
    float timeUntilNextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSpawn = 1 / spawnRate;
        timeUntilNextSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilNextSpawn <= 0)
        {
            var patrolPoint = rallyPoint.GetNextPoint();

            if (patrolPoint)
            {
                var newSoldier = Instantiate(soldierPrefab, spawnPoint.position, spawnPoint.rotation).GetComponent<AllyBehaviour>().patrolPoint = patrolPoint;
                patrolPoint.IsOccupied = true;

                timeUntilNextSpawn = timeBetweenSpawn;
            }
        }
        else
        {
            timeUntilNextSpawn -= Time.deltaTime;
        }
    }
}
