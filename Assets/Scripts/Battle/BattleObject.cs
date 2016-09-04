using UnityEngine;
using System.Collections;
using System;

public class BattleObject : FSprite {
    public GridManager gm;
    public Boolean blocking;
    public int team;
    public int gridX;
    public int gridY;
    public Boolean isDamageable = false;
    public int bloodMax = 100;
    public int bloodCount;
    public BattleObject (string Name, int gridX, int gridY, Boolean blocking) : base(Name)
    {
        this.bloodCount = bloodMax;
        this.gridX = gridX;
        this.gridY = gridY;
        this.sortZ = 2 - gridY;
        this.blocking = blocking;
    }

    public void updatePosition()
    {
        SetPosition(gm.gridXYToPosition(gridX, gridY));
        y += height / 2;
        this.sortZ = 2 - gridY;
    }


    public virtual void Update()
    {

    }

    public void collisionWithBO(BattleObject other)
    {

    }

    public void collisionWithPro(Projectile p)
    {

    }

    public void Damage(int damageAmount)
    {
        bloodCount -= damageAmount;
        if (bloodCount <= 0)
        {
            bloodCount = 0;
            Die();
        }
    }

    public void Die()
    {
        gm.destroyObject(this);
    }
}
