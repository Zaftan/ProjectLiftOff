using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class PowerUpAnimationS : AnimationSprite
{
    float timeStart;
    public PowerUpAnimationS() : base(Settings.ASSET_PATH + "Art/PowerUpShieldSprite.png", 7, 2, 32, addCollider: false)
    {
        timeStart = Time.time;
    }

    void Update()
    {
        Timer();
        this.x = MyGame.player.x - 50;
        this.y = MyGame.player.y;
        Animate();
    }

    void Timer()
    {
        if (Time.time > timeStart + 5000)
        {
            LateDestroy();
        }
    }


}