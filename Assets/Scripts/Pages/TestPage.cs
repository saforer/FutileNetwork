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
        gm.addObject(new BattleObject("Boulder", 2, 2, true));
        gm.addObject(new Mob("Ninja", 2, 1, true, 0));
        gm.addObject(new BattleObject("Boulder", 2, 0, true));
        gm.addObject(new Mob("Met", 4, 1, true, 1));
        
        
    }


    override
    public void Update()
    {
        gm.Update();
    }
}
