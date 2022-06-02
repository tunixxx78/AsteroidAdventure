using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody plrRb;
    JoystickManager joystickManager;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform startPosition;
    [SerializeField] GameObject plr;

    private void Awake()
    {
        plrRb = GetComponent<Rigidbody>();
        joystickManager = FindObjectOfType<JoystickManager>();
    }

    private void Update()
    {
        Move();

    }

    private void Move()
    {
        float y = joystickManager.InputVertical();
        float z = joystickManager.InputHorizontal();

        if (y > 0)
        {

            plrRb.AddForce(Vector3.up * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (y < 0)
        {

            plrRb.AddForce(-Vector3.up * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (z > 0)
        {

            plrRb.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (z < 0)
        {

            plrRb.AddForce(-Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);

            //Instantiate(plr, startPosition.position, Quaternion.identity);
        }
    }
}
