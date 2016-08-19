using UnityEngine;
using System.Collections;

public class TestPage : Page
{
    GridManager gm;
    public TestPage()
    {
        gm = new GridManager();
        gm.makeGrid(6, 3);
        gm.fillGrid();
        AddChild(gm);
        gm.addObject(new BattleObject("Box"), 0, 0);
    }


    override
    public void Update()
    {
        gm.Update();
    }
}
