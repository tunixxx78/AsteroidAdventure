using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainGame : MonoBehaviour
{
    PointsManager pointsManager;

    private void Awake()
    {
        pointsManager = FindObjectOfType<PointsManager>();
    }

    public void ReturnToMainGame()
    {
        pointsManager.SavePlayerPoints();

        SceneManager.LoadScene(1);
    }
}
