using UnityEngine;
using System.Collections;

public class Projectile : FSprite {
    public GridManager gm;
    public bool faceRight;
    public int gridX;
    public int gridY;
    public Projectile (string Name) : base (Name) { }

    public virtual void Update() { }
}

public class TestProjectile : Projectile
{
    public TestProjectile(BattleObject owner) : base("MetalBlade") {

    }

    override public void Update()
    {
        x += (faceRight ? -1 : 1) * 5f;
    }
}
