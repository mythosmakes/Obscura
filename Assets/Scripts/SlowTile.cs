using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTile : Tile
{
    [SerializeField] private float slowAmount; // default player speed is divided by this number when slowed
    private bool active = false;
    private PlayerController playerController;

    public override void Activate(PlayerController player)
    {
        base.Activate(player);
        playerController = player;
        if(active == false)
        {
            active = true;
            playerController.Slow(slowAmount);
        }
        
    }

    public override void Deactivate()
    {
        playerController.ResetSpeed();
        active = false;
    }
}
