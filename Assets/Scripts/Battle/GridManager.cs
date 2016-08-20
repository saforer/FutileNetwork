using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GridManager : FContainer{
    List<BattleObject> battleObjectList = new List<BattleObject>();
    Tile[,] grid;
    int width;
    int height;

    public Boolean isInGrid(int x, int y)
    {
        if (x < 0) return false;
        if (y < 0) return false;
        if (x > width-1) return false;
        if (y > height-1) return false;
        return true;
    }

    public void makeGrid(int x, int y)
    {
        width = x;
        height = y;
        grid = new Tile[x, y];
    }

    public void fillGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile t = new Tile(this, x, y);
                grid[x, y] = t;
                AddChild(t);
            }
        }
    }

    public Vector2 gridXYToPosition(int gridX, int gridY)
    {
        Vector2 output = new Vector2(0,0);

        output.x += 20f + (40 * gridX);
        output.y += 12.5f + (25 * gridY);

        return output;
    }

    public void addObject(BattleObject b)
    {
        if (isInGrid(b.gridX, b.gridY))
        {
            b.gm = this;
            b.updatePosition();
            battleObjectList.Add(b);
            AddChild(b);
        }
    }

    public void Update()
    {
        foreach (BattleObject b in battleObjectList)
        {
            b.Update();
        }
        foreach (Tile t in grid)
        {
            t.Update();
        }

    }
}