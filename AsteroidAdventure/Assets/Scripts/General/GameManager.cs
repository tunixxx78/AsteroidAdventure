using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject plr;
    [SerializeField] Vector3 spawnPosition = new Vector3(0, -13, 0);
    [SerializeField] int playerLives;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] TMP_Text lives;
    public bool shootRight = false, shootLeft = false;

    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.buildIndex != 0)
        {
            playerLives = playerMovement.plrLives;
            lives.text = playerLives.ToString();
        }
        
    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex != 0)
        {
            playerLives = playerMovement.plrLives;
            lives.text = playerLives.ToString();

            if (playerLives <= 0)
            {
                GameOverPanel.SetActive(true);
                plr.SetActive(false);
            }
        }
        
    }

    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void TryAgain(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
