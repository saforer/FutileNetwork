using UnityEngine;
using System;

public class Projectile : FSprite
{
    public GridManager gm;
    int gridX = 0;
    int gridY = 0;
    public BattleObject owner;
    public Projectile(String Name, BattleObject owner) : base(Name)
    {
        this.owner = owner;
        SetPosition(this.owner.GetPosition());
    }

    public void getTileOver()
    {
        int gridX = gm.positionToGridX(x);
        int gridY = gm.positionToGridY(y);
    }

    public void ownerDied()
    {
        
    }

    public virtual void Update()
    {

    }

    
}