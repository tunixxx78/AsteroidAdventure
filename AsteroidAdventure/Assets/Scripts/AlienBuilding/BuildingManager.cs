using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public List<GameObject> buildingBlocks = new List<GameObject>();
    [SerializeField] GameObject backToMainGame, gun, crosshair, currentBuilding;
    PlayerMovement playerMovement;
    [SerializeField] Transform spawnPosition;
    [SerializeField] GameObject[] buildings;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

        var buildingToSpawn = Random.Range(0, buildings.Length);

        Instantiate(buildings[buildingToSpawn], spawnPosition.position, Quaternion.identity);
    }

    private void Start()
    {
        currentBuilding = GameObject.Find("AlienObject(Clone)");
        int numberOfBlocks = currentBuilding.GetComponent<AlienObjectArray>().alienParts.Length;

        for (int i = 0; i < numberOfBlocks; i++)
        {
            buildingBlocks.Add(currentBuilding.GetComponent<AlienObjectArray>().alienParts[i]);
        }
    }

    private void Update()
    {
        if (buildingBlocks.Count == 0)
        {
            backToMainGame.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ShootingBuildings();
        }
    }

    public void ShootingBuildings()
    {
        GameObject bullet = Instantiate(playerMovement.bullets[1], gun.transform.position, Quaternion.identity);

        Rigidbody bulletrb = bullet.GetComponent<Rigidbody>();

        bulletrb.AddForce(new Vector3((playerMovement.player.transform.position.x + 0.5f), (playerMovement.player.transform.position.y + 8), playerMovement.player.transform.position.z) * 100 * Time.deltaTime, ForceMode.Impulse);

        Destroy(bullet, 5f);
    }

}
