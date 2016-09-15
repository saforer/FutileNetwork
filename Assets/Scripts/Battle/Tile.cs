using UnityEngine;
using System.Collections;

public class Tile : FSprite
{
    public GridManager gm;
    public int gridX;
    public int gridY;
    public bool ally;

    public Tile(int gridX, int gridY, bool ally) : base("EnemyTile")
    {
        this.gridX = gridX;
        this.gridY = gridY;
        this.ally = ally;
        if (ally)
        {
            SetElementByName("AllyTile");
        } else
        {
            SetElementByName("EnemyTile");
        }
    }
}