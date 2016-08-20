using UnityEngine;
using System.Collections;
using System;

public class BattleObject : FSprite {
    public GridManager gm;
    public Boolean blocking;
    public int gridX;
    public int gridY;
    public BattleObject (string Name, int gridX, int gridY, Boolean blocking) : base(Name)
    {
        this.gridX = gridX;
        this.gridY = gridY;
        this.blocking = blocking;
    }

    public void updatePosition()
    {
        SetPosition(gm.gridXYToPosition(gridX, gridY));
        y += height / 2;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && gm.isInGrid(gridX, gridY+1))
        {
            gridY++;
            updatePosition();
        }
        if (Input.GetKeyDown(KeyCode.A) && gm.isInGrid(gridX-1, gridY))
        {
            gridX--;
            updatePosition();
        }
        if (Input.GetKeyDown(KeyCode.S) && gm.isInGrid(gridX, gridY - 1))
        {
            gridY--;
            updatePosition();
        }
        if (Input.GetKeyDown(KeyCode.D) && gm.isInGrid(gridX + 1, gridY))
        {
            gridX++;
            updatePosition();
        }
    }
}
