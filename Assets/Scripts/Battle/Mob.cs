using UnityEngine;
using System.Collections;
using System;

//Any object able to move under its own will is a Mob. Moveable Object.
public class Mob : BattleObject
{
    public Mob(string Name) : base(Name) { }


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
    public Met() : base("Met")
    {
        damageable = true;
        hp = 5;
    }

}