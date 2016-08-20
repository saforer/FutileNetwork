using UnityEngine;
using System.Collections;

public class Tile : FSprite {
    public GridManager gm;
    public int gridX;
    public int gridY;

    public Tile(GridManager gm, int gridX, int gridY) : base("Tile")
    {
        this.gm = gm;
        this.gridX = gridX;
        this.gridY = gridY;
        SetPosition(gm.gridXYToPosition(gridX, gridY));
    }

    public void Update()
    {

    }
}
