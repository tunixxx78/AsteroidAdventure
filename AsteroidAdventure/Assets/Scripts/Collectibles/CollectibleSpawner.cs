using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] GameObject quad, collectibleInstance;
    [SerializeField] GameObject[] collectibles;

    private void Start()
    {
        SpawnCollectible();
    }

    public void SpawnCollectible()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenZ, screenX, screenY;
        Vector3 pos;

        var currentCollectible = Random.Range(0, collectibles.Length);

        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
        screenZ = 0;

        pos = new Vector3(screenX, screenY, screenZ);

        collectibleInstance = Instantiate(collectibles[currentCollectible], pos, Quaternion.identity);

    }

   
    
}
