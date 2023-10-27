using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFade : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material fadedMaterial;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
