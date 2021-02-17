using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
   public class Warning : Sprite
    {

       public Warning (float posX, float posY) : base(Settings.ASSET_PATH + "/Art/Warning.png")
        {
        this.x = posX;
        this.y = posY;
    }

    void OnCollision(GameObject obj)
    {
        if (obj is RoadBlock)
        {
            LateDestroy();
        }
    }


}

