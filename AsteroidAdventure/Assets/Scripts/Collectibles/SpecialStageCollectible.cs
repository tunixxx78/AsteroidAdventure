using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialStageCollectible : MonoBehaviour
{
    [SerializeField] int pointsAmount = 250;
    [SerializeField] int targetSceneIndex;
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

            pointsManager.SavePlayerPoints();

            SceneManager.LoadScene(targetSceneIndex);

        }
    }

}

