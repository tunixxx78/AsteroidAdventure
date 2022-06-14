using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text points, gameoverPoints, lives;
    public int plrPoints, pointsForExtraLevels, specialItemDelay;
    int plrLives;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("PlayerPoints") != 0)
        {
            plrPoints = PlayerPrefs.GetInt("PlayerPoints");
            plrLives = PlayerPrefs.GetInt("PlayerLives");
            pointsForExtraLevels = 0;
            //pointsForExtraLevels = PlayerPrefs.GetInt("ExtraLevels");
        }
        else
        {
            points.text = 0.ToString();
            gameoverPoints.text = 0.ToString();
            lives.text = 0.ToString();
        }


        

    }

    private void Update()
    {
        points.text = plrPoints.ToString();
        gameoverPoints.text = plrPoints.ToString();

        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex != 1)
        {
            lives.text = plrLives.ToString();
        }
        

        if (pointsForExtraLevels == specialItemDelay)
        {
            pointsForExtraLevels = 0;
            PlayerPrefs.SetInt("ExtraLevels", pointsForExtraLevels);
        }

        // for developement use only - reseting points on command!
        // delete this before build.

        if (Input.GetKeyDown(KeyCode.R))
        {
            plrPoints = 0;
            PlayerPrefs.SetInt("PlayerPoints", plrPoints);
        }
    }

    public void SavePlayerPoints()
    {
        PlayerPrefs.SetInt("PlayerPoints", plrPoints);
        PlayerPrefs.SetInt("ExtraLevels", pointsForExtraLevels);
        PlayerPrefs.SetInt("PlayerLives", plrLives);
    }
}
