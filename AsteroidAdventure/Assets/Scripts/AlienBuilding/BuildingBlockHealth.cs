using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlockHealth : MonoBehaviour
{
    [SerializeField] float BuildingStartHealth, currentHealth, damageAmount, pointsAmount;

    BuildingManager buildingManager;
    PointsManager pointsManager;

    private void Awake()
    {
        buildingManager = FindObjectOfType<BuildingManager>();
        pointsManager = FindObjectOfType<PointsManager>();
    }

    private void Start()
    {
        currentHealth = BuildingStartHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            buildingManager.buildingBlocks.Remove(this.gameObject);
            pointsManager.plrPoints = pointsManager.plrPoints + ((int)pointsAmount * 10);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "PLRAmmo")
        {
            if(currentHealth > 0)
            {
                pointsManager.plrPoints = pointsManager.plrPoints + (int)pointsAmount;
                currentHealth = currentHealth - damageAmount;
            }
        }
    }
}
