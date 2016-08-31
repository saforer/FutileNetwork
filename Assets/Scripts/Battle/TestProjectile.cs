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
        x += 10f;
        if (!gm.isWorldOverGrid(this.GetPosition(), height)) gm.destroyObject(this);
        getTileOver();
    }
}