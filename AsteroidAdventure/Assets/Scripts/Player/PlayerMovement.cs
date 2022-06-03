using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody plrRb;
    JoystickManager joystickManager;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 startPosition = new Vector3(0, -13, 0);
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
            plr.transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
        if (y < 0)
        {

            plrRb.AddForce(-Vector3.up * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            plr.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }

        if (z > 0)
        {

            plrRb.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            plr.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (z < 0)
        {

            plrRb.AddForce(-Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            plr.transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);

            plr.transform.position = startPosition;

            gameObject.SetActive(true);
            
        }
    }

    
}
