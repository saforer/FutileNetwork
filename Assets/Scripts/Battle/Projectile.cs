using UnityEngine;
using System;

public class Projectile : FSprite
{
    public GridManager gm;
    public Boolean isOverTiles = true;
    public int gridX = 0;
    public int gridY = 0;
    public BattleObject owner;
    public int damage = 50;
    public Projectile(String Name, BattleObject owner) : base(Name)
    {
        this.owner = owner;
        SetPosition(this.owner.GetPosition());
    }

    public void getTileOver()
    {
        isOverTiles = gm.isWorldOverGrid(new Vector2(x + (width/2), y - (height/2)));
        gridX = gm.positionToGridX(x - (width/2));
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
        gm.destroyProjectile(this);
        b.Damage(damage);
    }
}