using UnityEngine;
using System;

public class TestProjectile : Projectile
{
    public TestProjectile (BattleObject Owner) : base("Wheelie", Owner)
    {
        SetPosition(this.owner.GetPosition());
    }

    override
    public void Update()
    {
        x += 1;
    }
}