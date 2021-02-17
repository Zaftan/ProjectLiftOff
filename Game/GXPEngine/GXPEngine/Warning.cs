using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
   public class Warning : AnimationSprite
    {

       public Warning (float posX) : base(Settings.ASSET_PATH + "/Art/Warning.png",2,1)
        {
        this.x = posX;
        this.y = 150f;
    }

    void OnCollision(GameObject obj)
    {
        if (obj is RoadBlock)
        {
            LateDestroy();
        }
    }

    void Update()
    {
        Animate();
    }


}

