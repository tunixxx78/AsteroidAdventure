using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
