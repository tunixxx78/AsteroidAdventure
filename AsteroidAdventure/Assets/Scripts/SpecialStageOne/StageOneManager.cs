using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageOneManager : MonoBehaviour
{
    [SerializeField] TMP_Text points, time;
    public int S1Points;
    [SerializeField] float levelStartTime, timer;
    [SerializeField] bool timerIsOn = false;
    [SerializeField] GameObject backToMainGame, gun, crosshair, cockpitPanel;

    [SerializeField] Camera cam;

    PointsManager pointsManager;
    PlayerMovement playerMovement;

    private void Awake()
    {
        pointsManager = FindObjectOfType<PointsManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        points.text = 0.ToString();
        time.text = levelStartTime.ToString();
        timerIsOn = true;
    }

    private void Start()
    {
        timer = levelStartTime;
    }

    private void Update()
    {
        points.text = S1Points.ToString();
        string tempTimer = string.Format("{0:00}", timer);
        time.text = tempTimer.ToString();

        if (timerIsOn)
        {
            

            timer -= 1 * Time.deltaTime;
        }
        if (timer <= 0)
        {
            if (timerIsOn)
            {
                pointsManager.plrPoints = pointsManager.plrPoints + S1Points;
            }

            timerIsOn = false;
            time.text = 0.ToString();

            cockpitPanel.SetActive(false);
            backToMainGame.SetActive(true);
        }

        //ShootAsteroids();

        if (Input.GetButtonDown("Fire1"))
        {
            ShootingRocks();
        }
    }

    private void ShootAsteroids()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, crosshair.transform.position, out hit))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(cam.transform.position, crosshair.transform.position, Color.red);

            Destroy(hit.transform.gameObject);
            
        }

        Debug.DrawRay(cam.transform.position, crosshair.transform.position, Color.green, 2000);


    }

    public void ShootingRocks()
    {
        GameObject bullet = Instantiate(playerMovement.bullets[1], gun.transform.position, Quaternion.identity);

        Rigidbody bulletrb = bullet.GetComponent<Rigidbody>();

        bulletrb.AddForce(new Vector3((playerMovement.player.transform.position.x + 0.5f), (playerMovement.player.transform.position.y + 8), playerMovement.player.transform.position.z) * 100 * Time.deltaTime, ForceMode.Impulse);

        Destroy(bullet, 5f);
    }
}
