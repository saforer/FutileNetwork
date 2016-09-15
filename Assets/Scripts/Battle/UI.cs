using UnityEngine;
using System.Collections;

public class PlayerHealth : FContainer
{
    BattleObject player;

    public PlayerHealth (BattleObject player)
    {
        this.player = player;

        FSprite background = new FSprite("healthBackground");
        background.x = 2 + background.width/2 + .5f;
        background.y = -2 - background.height/2 - .5f + Futile.screen.height;

        AddChild(background);
    }
}

public class CustomBar : FContainer
{
    public CustomBar ()
    {
        FSprite background = new FSprite("customBackground");

        background.x = 28 + background.width/2 + .5f;
        background.y = -5 - background.height / 2 - .5f + Futile.screen.height;

        AddChild(background);
    }
}