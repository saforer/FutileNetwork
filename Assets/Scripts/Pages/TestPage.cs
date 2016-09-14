using UnityEngine;
using System.Collections;

public class TestPage : Page
{
    GridManager gm;
    public TestPage()
    {
        gm = new GridManager();
        gm.makeGrid(4, 3);
        gm.fillGrid();
        AddChild(gm);
        gm.shouldSortByZ = true;
        gm.addObject(new Mob("eightbit", 0, 0, true, 0));
        gm.addObject(new Mob("Met", 2, 0, true, 1));
        
        
    }


    override
    public void Update()
    {
        gm.Update();
    }
}
