using UnityEngine;
using System.Collections;

public class Tile : FSprite {
    public GridManager gm;
    public int gridX;
    public int gridY;
    public int team;

    public Tile(GridManager gm, int gridX, int gridY, int team) : base("EnemyTile")
    {
        this.team = team;
        this.gm = gm;
        this.gridX = gridX;
        this.gridY = gridY;
        SetPosition(gm.gridXYToPosition(gridX, gridY));
        loadTiles();
        updateElement();
    }

    void loadTiles()
    {

    }

    void updateElement()
    {
        if (team == 1)
        {
            SetElementByName("EnemyTile");
        } else {
            SetElementByName("AllyTile");
        }
    }

    public void Update()
    {

    }
}
