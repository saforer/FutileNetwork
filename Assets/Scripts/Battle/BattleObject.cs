using UnityEngine;
using System.Collections;
using System;

public class BattleObject : FSprite
{
    public Boolean enemy = false;
    public bool faceRight = false;
    public GridManager gm;
    public bool damageable = false;
    public int team;
    public int hp;
    public int gridX;
    public int gridY;
    public BattleObject(string Name) : base(Name) { }

    public virtual void BUpdate() { }
    public virtual void collidedWith(object o) { }


    public virtual void takeDamage(Projectile p)
    {
        hp -= p.damage;
        if (hp <= 0)
        {
            hp = 0;
            die();
        }
    }

    public virtual void die()
    {
        Debug.Log("BLARG I DEAD");
        gm.removeObject(this);
    }

    public void updatePos()
    {
        SetPosition(gm.gridToWorld(gridX, gridY));
        this.y += 9f;
    }
}