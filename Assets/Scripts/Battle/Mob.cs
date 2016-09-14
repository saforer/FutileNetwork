using UnityEngine;
using System;

public class Mob : BattleObject
{
    public Mob(String Name, int gridX, int gridY, Boolean blocking, int team) : base(Name, gridX, gridY, blocking)
    {
        this.team = team;
        isDamageable = true;
    }

    override
    public void Update()
    {
        if (team == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && (gm.moveable(gridX, gridY + 1, team)))
            {
                gridY++;
                updatePosition();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && gm.moveable(gridX - 1, gridY, team))
            {
                gridX--;
                updatePosition();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && gm.moveable(gridX, gridY - 1, team))
            {
                gridY--;
                updatePosition();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && gm.moveable(gridX + 1, gridY, team))
            {
                gridX++;
                updatePosition();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                gm.makeProjectile(new TestProjectile(this));
            }
        }
    }
}