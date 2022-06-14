using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] GameObject quad, collectibleInstance;
    [SerializeField] GameObject[] collectibles;
    [SerializeField] GameObject[] specialCollectibles;
    [SerializeField] float specialItemLiveSpan;
    

    public int currentCollectible, currentCollectible2;

    PointsManager pointsManager;

    private void Awake()
    {
        pointsManager = FindObjectOfType<PointsManager>();
    }
    private void Start()
    {
        SpawnCollectible();
    }

    public void SpawnCollectible()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenZ, screenX, screenY;
        Vector3 pos, pos2;

        if(pointsManager.pointsForExtraLevels == pointsManager.specialItemDelay)
        {
            currentCollectible2 = Random.Range(0, specialCollectibles.Length);
            Debug.Log("SPECIAL ITEM SPAWN");
        }
        else
        {
            currentCollectible = Random.Range(0, collectibles.Length);
            Debug.Log("NORMAL COLLECTIBLE SPAWN");
        }
        

        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
        screenZ = 0;

        pos = new Vector3(screenX, screenY, screenZ);
        pos2 = new Vector3(screenX + 5, screenY + 5, screenZ);

        if (pointsManager.pointsForExtraLevels == pointsManager.specialItemDelay)
        {
            var collectibleInstance2 = Instantiate(specialCollectibles[currentCollectible2], pos2, Quaternion.identity);
            collectibleInstance = Instantiate(collectibles[currentCollectible], pos, Quaternion.identity);

            Destroy(collectibleInstance2, specialItemLiveSpan);
        }
        else
        {
            collectibleInstance = Instantiate(collectibles[currentCollectible], pos, Quaternion.identity);
        }
            

    }

   
    
}
