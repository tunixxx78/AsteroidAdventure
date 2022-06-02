using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject quad;
    [SerializeField] GameObject[] obstacles;
    [SerializeField] float obstacleLifetime;
    [SerializeField] float minSpeed, maxSpeed;

    [SerializeField] float delayTime;

    private void Start()
    {
        SpawnFrontObstacles();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFrontObstacles();
        }
    }

    public void SpawnFrontObstacles()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenZ, screenX, screenY;
        Vector3 pos;

        var currentObstacle = Random.Range(0, obstacles.Length);
        var obsSpeed = Random.Range(minSpeed, maxSpeed);

        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
        screenZ = 70;

        pos = new Vector3(screenX, screenY, screenZ);

        var obsInstance = Instantiate(obstacles[currentObstacle], pos, Quaternion.identity);
        obsInstance.GetComponent<Obstacle>().speed = obsSpeed;

        Destroy(obsInstance, obstacleLifetime);

        StartCoroutine(SpawnDelay(delayTime));
    }

    IEnumerator SpawnDelay(float time)
    {
        yield return new WaitForSeconds(time);

        SpawnFrontObstacles();
    }
}
