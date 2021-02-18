using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
   

   public class GunDude : Sprite
    {
      public GunDude() : base(Settings.ASSET_PATH + "/Art/GunDude.png", addCollider: false)
       {
       }

    void Update()
    {
        Rotate();
        this.x = MyGame.player.x - 40;
        this.y = MyGame.player.y + 45;
    }

    void Rotate()
    {
    }
}
