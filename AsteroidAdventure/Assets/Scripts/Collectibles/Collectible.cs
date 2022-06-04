using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] int pointsAmount = 10;
    PointsManager pointsManager;

    private void Awake()
    {
        pointsManager = FindObjectOfType<PointsManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        

        if (collider.gameObject.tag == "Player")
        {
            pointsManager.plrPoints = pointsManager.plrPoints + pointsAmount;
            FindObjectOfType<CollectibleSpawner>().SpawnCollectible();
            Destroy(gameObject);

        }
    }
   
}
