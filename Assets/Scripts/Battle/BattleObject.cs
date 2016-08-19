using UnityEngine;
using System.Collections;

public class BattleObject : FSprite {
    Tile parent;
    int gridX;
    int gridY; 

    public BattleObject(string Image) : base(Image)
    {

    }

    public void setParent(Tile t)
    {
        parent = t;
        updatePosition();
    }

    void updatePosition()
    {
        gridX = parent.gridX;
        gridY = parent.gridY;
        Vector2 position = parent.gm.gridXYToPosition(gridX, gridY);
        position.y += (height/2);
        SetPosition(position);
    }

    public void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Debug.Log("W Pressed");
            parent.gm.Move(this);
        }
    }

    public Tile getParent()
    {
        return parent;
    }
}
