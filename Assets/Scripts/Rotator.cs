using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 rotationDirection;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }
}
