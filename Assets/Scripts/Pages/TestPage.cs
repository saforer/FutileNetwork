using UnityEngine;
using System.Collections;

public class TestPage : Page
{
    GridManager gm;
    public TestPage()
    {
        gm = new GridManager();
        gm.makeGrid(4, 2);
        gm.fillGrid();
        AddChild(gm);
        gm.shouldSortByZ = true;
        gm.addObject(new Mob("Box", 1, 1, true, 0));
        gm.addObject(new Mob("Met", 2, 1, true, 1));
        
        
    }


    override
    public void Update()
    {
        gm.Update();
    }
}
