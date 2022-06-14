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
    [SerializeField] GameObject[] bullets;
    [SerializeField] Transform player, bulletSpawnpoint;

    public int plrLives;
    GameManager gameManager;
    

    private void Awake()
    {
        plrRb = GetComponent<Rigidbody>();
        joystickManager = FindObjectOfType<JoystickManager>();
        gameManager = FindObjectOfType<GameManager>();
        plrLives = 3;
        PlayerPrefs.SetInt("PlayerLives", plrLives);
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

    public void ShootingOne()
    {
        Debug.Log("BANGBANGBANG");

        var bulletInstance = Instantiate(bullets[0], bulletSpawnpoint.position, bullets[0].transform.rotation);
        bulletInstance.transform.Rotate(0, 0, 180);

        if (plr.transform.rotation.eulerAngles.y == 180)
        {
            Debug.Log("ALUS ON KÄÄNTYNYT");
            gameManager.shootLeft = true;
            gameManager.shootRight = false;
        }
        else
        {
            gameManager.shootLeft = false;
            gameManager.shootRight = true;
        }
        
        Destroy(bulletInstance, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            plrLives = plrLives - 1;
            PlayerPrefs.SetInt("PlayerLives", plrLives);

            gameObject.SetActive(false);

            plr.transform.position = startPosition;

            gameObject.SetActive(true);
            
        }
    }

    
}
