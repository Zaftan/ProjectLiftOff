using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

   public class PowerUpAnimationL: AnimationSprite
    {
        float timeStart;
    public PowerUpAnimationL() : base (Settings.ASSET_PATH + "Art/PowerUpLifeSprite.png",8,4, 32, addCollider: false)
        {
        timeStart = Time.time;
        }   
    
    void Update()
    {
        Timer();
        this.x = MyGame.player.x -50;
        this.y = MyGame.player.y;
        Animate();
    }

    void Timer()
    {
        if (Time.time > timeStart + 3000)
        {
            LateDestroy();
        }
    }


}

