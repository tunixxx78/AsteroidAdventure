using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody obsRB;
    [SerializeField] int Verticaldirection, horizontalDirection;
    public float speed;

    private void Awake()
    {
        obsRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        obsRB.velocity = new Vector3(horizontalDirection, Verticaldirection, 0) * speed;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "AttackZone")
        {
            Destroy(this.gameObject);
        }
    }
}
