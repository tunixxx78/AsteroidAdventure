using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject plr;
    [SerializeField] Vector3 spawnPosition = new Vector3(0, -13, 0);

    private void Start()
    {
        //SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        var plrInstance = Instantiate(plr, spawnPosition, Quaternion.identity);
        plrInstance.transform.SetParent(GameObject.Find("Player").transform);
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
