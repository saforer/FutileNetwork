using UnityEngine;
using System;
using System.Collections;

public class GridManager : FContainer{
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

    public void addObject(BattleObject b, int gridX, int gridY)
    {
        Tile t = grid[gridX, gridY];
        if (t.heldObject != null) return;
        t.heldObject = b;
        b.setParent(t);
        AddChild(b);
    }

    public void Update()
    {
        foreach (Tile t in grid) {
            t.Update();
        }
    }

    public void Move(BattleObject b)
    {
        Tile t = b.getParent();
        int x = t.gridX;
        int y = t.gridY + 1;

        if (!isInGrid(x, y)) return;
        Tile tG = grid[x, y];
        if (tG.heldObject != null) return;
        tG.heldObject = t.heldObject;
        b.setParent(tG);
    }
}