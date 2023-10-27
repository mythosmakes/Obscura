using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public abstract void Activate(PlayerController playerController);

    public abstract void Deactivate();
}
