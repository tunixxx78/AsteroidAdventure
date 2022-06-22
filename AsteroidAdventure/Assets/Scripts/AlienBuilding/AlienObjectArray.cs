using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienObjectArray : MonoBehaviour
{
    public GameObject[] alienParts;
    [SerializeField] float rotationSpeed = 10f;
    Rigidbody objectRB;
    [SerializeField] bool building = false;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (building)
        {
            objectRB.transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));
        }
        
    }
}
