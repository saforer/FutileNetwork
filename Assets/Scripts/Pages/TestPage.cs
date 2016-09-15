using UnityEngine;
using System.Collections;

public class TestPage : Page
{
    GridManager gm;
    public TestPage()
    {
        gm = new GridManager();
        gm.makeGrid(4, 3);
        AddChild(gm);
        Player p = new Player();
        gm.addBattleObject(p, 1, 1);
        gm.addBattleObject(new BattleObject("Met"), 2, 1);
        AddChild(new PlayerHealth(p));
        AddChild(new CustomBar());
    }


    override
    public void Update()
    {
        gm.Update();
    }
}