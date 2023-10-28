using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material alternateMaterial;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public virtual void Activate(PlayerController playerController) 
    {
        meshRenderer.material = alternateMaterial;
    }

    public virtual void Deactivate()
    { 
        meshRenderer.material = defaultMaterial;
    }
}
