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
    [SerializeField] Transform player;

    public int plrLives;
    

    private void Awake()
    {
        plrRb = GetComponent<Rigidbody>();
        joystickManager = FindObjectOfType<JoystickManager>();
        plrLives = 3;
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
            //player.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            //plrRb.MovePosition(transform.position + (Vector3.up * moveSpeed * Time.deltaTime));
            //plrRb.velocity = Vector3.up * moveSpeed * Time.deltaTime;
            plrRb.AddForce(Vector3.up * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            plr.transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
        if (y < 0)
        {
            //player.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
            //plrRb.MovePosition(transform.position + (-Vector3.up * moveSpeed * Time.deltaTime));
            //plrRb.velocity = -Vector3.up * moveSpeed * Time.deltaTime;
            plrRb.AddForce(-Vector3.up * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            plr.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }

        if (z > 0)
        {
            //player.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //plrRb.MovePosition(transform.position + (Vector3.right * moveSpeed * Time.deltaTime));
            //plrRb.velocity = Vector3.right * moveSpeed * Time.deltaTime;
            plrRb.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            plr.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (z < 0)
        {
            //player.Translate(Vector3.left * -moveSpeed * Time.deltaTime);
            //plrRb.MovePosition(transform.position + (-Vector3.right * moveSpeed * Time.deltaTime));
            //plrRb.velocity = -Vector3.right * moveSpeed * Time.deltaTime;
            plrRb.AddForce(-Vector3.right * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            plr.transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            plrLives = plrLives - 1;

            gameObject.SetActive(false);

            plr.transform.position = startPosition;

            gameObject.SetActive(true);
            
        }
    }

    
}
