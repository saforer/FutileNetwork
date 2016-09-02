using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GridManager : FContainer{
    List<BattleObject> battleObjectList = new List<BattleObject>();
    List<BattleObject> toRemoveBattle = new List<BattleObject>();
    List<Projectile> projectileList = new List<Projectile>();
    List<Projectile> toRemoveProjectile = new List<Projectile>();
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

    public Boolean isWorldOverGrid(Vector2 pos)
    {
        float minWorldCoordinateX = -(40 * (width/2)) + Futile.screen.halfWidth;
        float maxWorldCoordinateX = (40 * (width/2)) + Futile.screen.halfWidth;
        float minWorldCoordinateY = 0f;
        float maxWorldCoordinateY = (25 * height);

        if (pos.x > minWorldCoordinateX &&  pos.x < maxWorldCoordinateX)
        {
            if (pos.y-(height/2) > minWorldCoordinateY && pos.y-(height/2) < maxWorldCoordinateY) return true;
        }

        return false;
    }

    public int positionToGridX(float worldX)
    {
        float tileWidth = 40f;
        // Works with a 6 wide, not anything else return Mathf.FloorToInt((worldX / tileWidth));
        return Mathf.FloorToInt((worldX - (Futile.screen.halfWidth)) / tileWidth) + ((width / 2));
    }

    public int positionToGridY(float worldY)
    {
        if (worldY > 0 && worldY < 25f) return 0;
        if (worldY > 26f && worldY < 50f) return 1;
        if (worldY > 51f && worldY < 75f) return 2;
        return 0;
    }

    public Vector2 gridXYToPosition(int gridX, int gridY)
    {
        Vector2 output = new Vector2(0,0);

        output.x += 20f + (40 * gridX) + Futile.screen.halfWidth;
        float pixelWidth = width * 40;
        output.x -= pixelWidth / 2;
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
        p.gm = this;
        projectileList.Add(p);
        AddChild(p);
    }

    public void destroyObject(Projectile p)
    {
        RemoveChild(p);
        toRemoveProjectile.Add(p);
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
        //Check for collisions
        foreach (BattleObject b in battleObjectList) {
            foreach (BattleObject b2 in battleObjectList)
            {
                if (b != b2)
                {
                    if (b.gridX == b2.gridX && b.gridY == b2.gridY)
                    {
                        if (b.blocking || b2.blocking)
                        {
                            b.collisionWithBO(b2);
                            b2.collisionWithBO(b);
                        }
                    }
                }
            }

            foreach (Projectile p in projectileList)
            {
                if (b.gridX == p.gridX && b.gridY == p.gridY)
                {
                    if (b.team != p.owner.team)
                    {
                        b.collisionWithPro(p);
                        p.collisionWithBO(b);
                    }
                }
            }
        }
        foreach (Projectile p in toRemoveProjectile)
        {
            projectileList.Remove(p);
        }
        toRemoveProjectile.Clear();
    }
}