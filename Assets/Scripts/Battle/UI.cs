using UnityEngine;
using System.Collections;

public class PlayerHealth : FContainer
{
    BattleObject player;
    FLabel health;
    public PlayerHealth (Player player)
    {
        
        this.player = player;
        player.ph = this;
        FSprite background = new FSprite("healthBackground");
        background.x = 2 + background.width / 2 + .5f;
        background.y = -2 - background.height / 2 - .5f + Futile.screen.height;
        health = new FLabel("font", player.hp.ToString());
        health.x = 2 + background.width / 2 + .5f;
        health.y = -2 - background.height / 2 - .5f + Futile.screen.height;
        AddChild(background);
        AddChild(health);
    }

    public void updateHealth()
    {
        health.text = player.hp.ToString();
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