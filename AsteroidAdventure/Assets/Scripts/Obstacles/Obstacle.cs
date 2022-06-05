using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody obsRB;
    [SerializeField] int Verticaldirection, horizontalDirection, depthDirection, pointsFromDestruction;
    [SerializeField] Material dangerZone;
    public float speed;

    PointsManager pointsManager;

    private void Awake()
    {
        obsRB = GetComponent<Rigidbody>();
        pointsManager = FindObjectOfType<PointsManager>();
    }

    private void FixedUpdate()
    {

        obsRB.velocity = new Vector3(horizontalDirection, Verticaldirection, depthDirection) * speed;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "AttackZone")
        {
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "DangerZone")
        {
            GetComponentInChildren<MeshRenderer>().material = dangerZone;
        }

        if (collider.gameObject.tag == "PLRAmmo")
        {
            pointsManager.plrPoints = pointsManager.plrPoints + pointsFromDestruction;
            Destroy(gameObject);
        }
    }
}
