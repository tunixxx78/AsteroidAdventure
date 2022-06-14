using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainGame : MonoBehaviour
{
    public void ReturnToMainGame()
    {
        SceneManager.LoadScene(1);
    }
}
