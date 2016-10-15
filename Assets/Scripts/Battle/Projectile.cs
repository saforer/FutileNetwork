using UnityEngine;
using System.Collections;

public class Projectile : FSprite {
    public GridManager gm;
    public bool faceRight = false;
    public int gridX;
    public int gridY;
    public BattleObject owner;
    public Projectile (string Name) : base (Name) { }

    public virtual void PUpdate() { }
    public virtual void collidedWith(object o) { }

    public void updatePos() {
        if (!gm.isWorldOverGrid(GetPosition()))
        {
            gm.removeObject(this);
        } else
        {
            Vector2 tempPos = gm.worldToGrid(GetPosition());
            gridX = Mathf.FloorToInt(tempPos.x);
            gridY = Mathf.FloorToInt(tempPos.y);
        }
    }
}

public class TestProjectile : Projectile
{
    public TestProjectile(BattleObject owner) : base("MetalBlade") {
        faceRight = true;
        this.owner = owner;
    }

    override public void PUpdate()
    {
        x += (faceRight ? 1 : -1) * 5f;
        updatePos();
    }
}
public class TestEnemyProjectile : Projectile
{
    public TestEnemyProjectile(BattleObject owner) : base("MetalBlade")
    {
        faceRight = false;
        this.owner = owner;
    }

    override public void PUpdate()
    {
        x += (faceRight ? 1 : -1) * 5f;
        updatePos();
    }
}
