using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GridManager : FContainer
{
    int width;
    int height;
    Tile[,] tiles;
    List<BattleObject> battleObjectList = new List<BattleObject>();
    List<Projectile> projectileObjectList = new List<Projectile>();
    List<object> removeThis = new List<object>();

    public void makeGrid(int width, int height)
    {
        shouldSortByZ = true;
        this.width = width;
        this.height = height;
        tiles = new Tile[width, height];
        fillGrid();
    }

    public void fillGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //holy crap an actual conditional operator.
                tiles[i, j] = new Tile(i, j, (i < (width/2))? true : false);
                drawTile(tiles[i, j]);
                AddChild(tiles[i, j]);
            }
        }
    }

    public void drawTile(Tile t)
    {
        t.SetPosition(gridToWorld(t.gridX, t.gridY));

        t.sortZ = t.gridY;
    }

    public Boolean isWorldOverGrid(Vector2 pos)
    {
        float minWorldCoordinateX = -(40 * (width / 2)) + Futile.screen.halfWidth;
        float maxWorldCoordinateX = (40 * (width / 2)) + Futile.screen.halfWidth;
        float minWorldCoordinateY = 0f;
        float maxWorldCoordinateY = (25 * height);

        if (pos.x > minWorldCoordinateX && pos.x < maxWorldCoordinateX)
        {
            if (pos.y - (height / 2) > minWorldCoordinateY && pos.y - (height / 2) < maxWorldCoordinateY) return true;
        }

        return false;
    }

    public Vector2 worldToGrid(Vector2 pos)
    {
        float tileWidth = 40f;
        // Works with a 6 wide, not anything else return Mathf.FloorToInt((worldX / tileWidth));
        float gridX = Mathf.FloorToInt((pos.x - (Futile.screen.halfWidth)) / tileWidth) + ((width / 2));

        float gridY = 0f;
        if (pos.y > 0 && pos.y < 25f) gridY = 0f;
        if (pos.y > 26f && pos.y < 50f) gridY = 1f;
        if (pos.y > 51f && pos.y < 75f) gridY = 2f;
        
        return new Vector2(gridX, gridY);
    }

    public Vector2 gridToWorld(int x, int y)
    {
        int tileWidth = 32;
        int tileHeight = 18;
        int halfWidth = 16;
        int halfHeight = 9;

        //Floats tagged on the end because for whatever reason weird stuff happens if I don't have them. Programming in a nutshell ¯\_(ツ)_/¯
        float vectX = (x * tileWidth) + halfWidth + .5f + (Futile.screen.halfWidth - halfWidth * width);
        float vectY = (y * tileHeight) + halfHeight - .5f;

        if (y >= 1) vectY -= y;

        return new Vector2(vectX, vectY);
    }

    public void addBattleObject(BattleObject b, int gridX, int gridY)
    {
        int objectOffsetZ = 10;
        b.SetPosition(gridToWorld(gridX, gridY));
        b.gm = this;
        b.y += 9f;
        b.sortZ = gridY + objectOffsetZ;
        b.gridX = gridX;
        b.gridY = gridY;
        battleObjectList.Add(b);
        AddChild(b);
    }

    public void addProjectile(Projectile p, int gridX, int gridY)
    {
        int projectileOffsetZ = 20;
        p.SetPosition(gridToWorld(gridX, gridY));
        p.gm = this;
        p.y += 9f;
        p.sortZ = gridY + projectileOffsetZ;
        p.gridX = gridX;
        p.gridY = gridY;
        projectileObjectList.Add(p);
        AddChild(p);
    }

    public void removeObject(object o)
    {
        removeThis.Add(o);
    }

    public Boolean isInBounds(int x, int y)
    {
        if ((x < 0) || (x > width - 1)) return false;
        if ((y < 0) || (y > height - 1)) return false;
        return true;
    }

    public Boolean isAbleToMove(int x, int y)
    {
        foreach (BattleObject b in battleObjectList)
        {
            if ((b.gridX == x) && (b.gridY == y))
            {
                return false;
            }
        }
        return true;
    }

    public void Move(Directions d, BattleObject b)
    {
        int x = b.gridX;
        int y = b.gridY;

        switch (d)
        {
            case Directions.UP:
                y++;
                break;
            case Directions.DOWN:
                y--;
                break;
            case Directions.LEFT:
                x--;
                break;
            case Directions.RIGHT:
                x++;
                break;
        }

        Move(x, y, b);
    }
    
    public Boolean tileIsOnTeam(int x, BattleObject b)
    {
        int tileTeam = (x < width / 2) ? 0 : 1;
        if (tileTeam == b.team) return true;
        return false;
    }

    public void Move(int x, int y, BattleObject b)
    {
        if (isInBounds(x,y))
        {
            if (isAbleToMove(x, y))
            {
                if (tileIsOnTeam(x, b))
                {
                    b.gridX = x;
                    b.gridY = y;
                    b.updatePos();
                }
            }
        }
    }


    public void Update()
    {
        //Update enemies&allies&objects
        foreach (BattleObject b in battleObjectList)
        {
            b.BUpdate();
        }
        //Update bullets
        foreach (Projectile p in projectileObjectList)
        {
            p.PUpdate();
        }

        //Check for collisions with bullets&objects
        foreach (BattleObject b in battleObjectList)
        {
            foreach (BattleObject b2 in battleObjectList)
            {
                if ((b != b2) && (b.gridX == b2.gridX) && (b.gridY == b2.gridY))
                {
                    b.collidedWith(b2);
                    b2.collidedWith(b);
                }
            }

            foreach (Projectile p in projectileObjectList)
            {
                if ((b.gridX == p.gridX) && (b.gridY == p.gridY) && (b != p.owner))
                {
                    b.collidedWith(p);
                    p.collidedWith(b);
                }
            }
        }

        //Remove shit if need be
        foreach (object o in removeThis)
        {
            if (o is Projectile)
            {
                projectileObjectList.Remove((Projectile) o);
            }

            if (o is BattleObject)
            {
                battleObjectList.Remove((BattleObject)o);
            }
            RemoveChild((FSprite)o);
        }

        Boolean winBool = true;
        //Did we win?
        foreach (BattleObject b in battleObjectList)
        {
            if (b.enemy == true)
            {
                winBool = false;
            }
        }
        if (winBool)
        {
            win();
        }
    }

    public void lose()
    {
        FLabel lab = new FLabel("font", "You Lose");
        lab.x = Futile.screen.width/2;
        lab.y = Futile.screen.height / 2;
        lab.sortZ = 100;
        AddChild(lab);
    }

    public void win()
    {
        FLabel lab = new FLabel("font", "You Win");
        lab.x = Futile.screen.width / 2;
        lab.y = Futile.screen.height / 2;
        lab.sortZ = 100;
        AddChild(lab);
    }
}