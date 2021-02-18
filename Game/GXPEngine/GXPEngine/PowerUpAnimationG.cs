using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class PowerUpAnimationG : Sprite
{
    float timeStart;
    public PowerUpAnimationG() : base(Settings.ASSET_PATH + "Art/PowerUpGunSprite.png", addCollider: false)
    {
        timeStart = Time.time;
    }

    void Update()
    {
        Timer();
        this.x = MyGame.player.x - 82;
        this.y = MyGame.player.y + 30;
    }

    void Timer()
    {
        if (Time.time > timeStart + 10000)
        {
            LateDestroy();
        }
    }


}