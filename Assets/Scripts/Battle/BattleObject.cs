using UnityEngine;
using System.Collections;
using System;

public class BattleObject : FSprite
{
    public bool faceRight = false;
    public GridManager gm;
    public bool damageable = false;
    public int hp;
    public int gridX;
    public int gridY;
    public BattleObject(string Name) : base(Name) { }

    public virtual void Update() { }
}