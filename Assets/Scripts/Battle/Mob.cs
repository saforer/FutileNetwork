using UnityEngine;
using System.Collections;
using System;

//Any object able to move under its own will is a Mob. Moveable Object.
public class Mob : BattleObject
{
    public Mob(string Name) : base(Name) { }

    public override void collidedWith(object o)
    {
        if (o is Projectile)
        {
            Debug.Log("MET WAS HIT");
            gm.removeObject(o);
        }
    }

    public void takeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if (hp >= 0)
        {
            hp = 0;
            die();
        }
    }

    public void die()
    {
        Debug.Log("BLARG I DEAD");
    }
}


public class Met : Mob
{
    Boolean movUp = true;
    float movCount = 0f;
    float fireCount = 0f;
    public Met() : base("Met")
    {
        damageable = true;
        hp = 5;
    }

    override
    public void BUpdate()
    {
        AI();
    }

    void AI()
    {
        float dt = Time.deltaTime;
        //Shoot
        if (fireCount <= 1f)
        {
            fireCount += dt;
        } else
        {
            fireCount = 0f;
            gm.addProjectile(new TestEnemyProjectile(this), gridX, gridY);
        }
        //Move
        if (movCount <= .40f)
        {
            movCount += dt;
        }
        else
        {
            movCount = 0f;
            if (movUp)
            {
                if (gridY != 2)
                {
                    gm.Move(Directions.UP, this);
                }
                else
                {
                    movUp = false;
                    gm.Move(Directions.DOWN, this);
                }
            }
            else
            {
                if (gridY != 0)
                {
                    gm.Move(Directions.DOWN, this);
                }
                else
                {
                    movUp = true;
                    gm.Move(Directions.UP, this);
                }
            }
        }
    }
}