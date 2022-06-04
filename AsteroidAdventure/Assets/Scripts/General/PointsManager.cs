using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text points;
    public int plrPoints;

    private void Awake()
    {
        points.text = 0.ToString();

    }

    private void Update()
    {
        points.text = plrPoints.ToString();
    }
}
