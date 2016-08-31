using UnityEngine;
using System;

public class Projectile : FSprite
{
    public GridManager gm;
    public int gridX = 0;
    public int gridY = 0;
    public BattleObject owner;
    public Projectile(String Name, BattleObject owner) : base(Name)
    {
        this.owner = owner;
        SetPosition(this.owner.GetPosition());

    }

    public void getTileOver()
    {
        gridX = gm.positionToGridX(x);
        gridY = gm.positionToGridY(y - (height/2));
    }

    public void ownerDied()
    {
        
    }

    public virtual void Update()
    {

    }

    public void collisionWithBO(BattleObject b)
    {
        gm.destroyObject(this);
    }
}