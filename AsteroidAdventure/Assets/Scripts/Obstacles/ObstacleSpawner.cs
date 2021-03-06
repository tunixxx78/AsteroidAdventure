using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacle;
    [SerializeField] Transform[] obstacleSpawnpoints;
    [SerializeField] float obstacleLifetime;
    [SerializeField] float minSpeed, maxSpeed;

    [SerializeField] float delayTime;

    private void Start()
    {
        /*
        var obsToSpawn = Random.Range(0, obstacle.Length);
        var currentSpawnpoint = Random.Range(0, obstacleSpawnpoints.Length);
        var obsSpeed = Random.Range(minSpeed, maxSpeed);

        var obstacleInstance = Instantiate(obstacle[obsToSpawn], obstacleSpawnpoints[currentSpawnpoint].position, Quaternion.identity);
        obstacleInstance.GetComponent<Obstacle>().speed = obsSpeed;

        Destroy(obstacleInstance, obstacleLifetime);
        */

        SpawnObstacle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        var obsToSpawn = Random.Range(0, obstacle.Length);
        var currentSpawnpoint = Random.Range(0, obstacleSpawnpoints.Length);
        var obsSpeed = Random.Range(minSpeed, maxSpeed);

        var obstacleInstance = Instantiate(obstacle[obsToSpawn], obstacleSpawnpoints[currentSpawnpoint].position, Quaternion.identity);
        obstacleInstance.GetComponent<Obstacle>().speed = obsSpeed;

        Destroy(obstacleInstance, obstacleLifetime);

        StartCoroutine(SpawnDelay(delayTime));
    }

    IEnumerator SpawnDelay(float time)
    {
        yield return new WaitForSeconds(time);

        SpawnObstacle();
    }
}
