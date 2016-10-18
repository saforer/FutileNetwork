using UnityEngine;
using System.Collections;
using System;

public class Player : Mob
{
    public PlayerHealth ph;
    public Player() : base("eightbit")
    {
        team = 0;
        hp = 5;
    }
    

    public override void BUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gm.Move(Directions.UP, this);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gm.Move(Directions.DOWN, this);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gm.Move(Directions.LEFT, this);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gm.Move(Directions.RIGHT, this);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnMetalBlade();
        }
    }

    public void SpawnMetalBlade()
    {
        gm.addProjectile(new TestProjectile(this), gridX, gridY);
    }

    override
    public void collidedWith(object o)
    {
        if (o is Projectile)
        {
            takeDamage((Projectile)o);
            ph.updateHealth();
            gm.removeObject(o);
        }
    }

    override
    public void die()
    {
        gm.removeObject(this);
        gm.lose();
    }


}