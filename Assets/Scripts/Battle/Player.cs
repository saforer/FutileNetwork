using UnityEngine;
using System.Collections;
using System;

public class Player : Mob
{

    public Player() : base("eightbit") { }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnMetalBlade();
        }
    }

    public void SpawnMetalBlade()
    {
        gm.addProjectile(new TestProjectile(this), gridX, gridY);
    }
}