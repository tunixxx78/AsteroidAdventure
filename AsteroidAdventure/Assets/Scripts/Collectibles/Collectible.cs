using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            FindObjectOfType<CollectibleSpawner>().SpawnCollectible();
            Destroy(gameObject);

        }
    }
   
}
