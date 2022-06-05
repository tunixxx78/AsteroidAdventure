using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOne : MonoBehaviour
{
    Rigidbody bulletRB;
    GameManager gameManager;

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

    }

    private void Start()
    {
        //bulletRB.AddForce(-Vector3.right * 1000 * Time.deltaTime, ForceMode.Impulse);
        if (gameManager.shootLeft == true)
        {
            bulletRB.AddForce(-Vector3.right * 1000 * Time.deltaTime, ForceMode.Impulse);
        }
        if (gameManager.shootRight == true)
        {
            bulletRB.AddForce(Vector3.right * 1000 * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        
    }
}
