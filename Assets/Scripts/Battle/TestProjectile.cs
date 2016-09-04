using UnityEngine;
using System;

public class TestProjectile : Projectile
{
    public TestProjectile (BattleObject Owner) : base("Wheelie", Owner)
    {
        this.owner = Owner;
        SetPosition(this.owner.GetPosition());
    }

    override
    public void Update()
    {
        x += 5f;
        
        
        getTileOver();
        if (!isOverTiles) gm.destroyProjectile(this);
    }
}