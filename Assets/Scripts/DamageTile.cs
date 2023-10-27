using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTile : Tile
{
    private bool active = false;

    public override void Activate(PlayerController playerController)
    {
        if (active == false)
        {
            active = true;
            playerController.CorruptionEffect();
        }
    }
    public override void Deactivate()
    {
        active = false;
    }
}
