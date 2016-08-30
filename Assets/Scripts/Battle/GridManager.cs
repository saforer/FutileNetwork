using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GridManager : FContainer{
    List<BattleObject> battleObjectList = new List<BattleObject>();
    List<Projectile> projectileList = new List<Projectile>();
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

    public Boolean blockingObject(int x, int y)
    {
        foreach (BattleObject bo in battleObjectList)
        {
            if (bo.gridX == x && bo.gridY == y)
            {
                if (bo.blocking == true)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public Boolean tileMoveable(int x, int y, int team)
    {
        if (!isInGrid(x, y)) return false;
        Tile t = grid[x, y];
        if (t.team == team) return true;
        return false;
    }

    public Boolean moveable(int x, int y, int team)
    {
        if (!isInGrid(x, y)) return false;
        if (!blockingObject(x, y)) return false;
        if (!tileMoveable(x, y, team)) return false;

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
                int team = 0;
                if (x >= (width / 2)) team = 1;
                Tile t = new Tile(this, x, y, team);
                grid[x, y] = t;
                AddChild(t);
            }
        }
    }

    public int positionToGridX(float worldX)
    {
        int output = Mathf.FloorToInt(worldX);
        output -= 20;
        return 0;
    }

    public int positionToGridY(float worldY)
    {
        return 0;
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

    public void makeProjectile(Projectile p)
    {
        projectileList.Add(p);
        AddChild(p);
    }

    public void Update()
    {
        foreach (BattleObject b in battleObjectList)
        {
            b.Update();
        }
        foreach (Projectile p in projectileList)
        {
            p.Update();
        }
        foreach (Tile t in grid)
        {
            t.Update();
        }
    }
}