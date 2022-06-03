using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text points;

    private void Awake()
    {
        points.text = 100.ToString();
    }
}
