using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GridManager : FContainer
{
    int width;
    int height;
    Tile[,] tiles;

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
        b.y += 9f;
        b.sortZ = gridY + objectOffsetZ;
        AddChild(b);
    }

    public void Update()
    {

    }
}