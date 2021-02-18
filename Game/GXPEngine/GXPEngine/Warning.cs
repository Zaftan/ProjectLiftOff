using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
   public class Warning : AnimationSprite
    {
        Sound WarningSound = new Sound(Settings.ASSET_PATH + "SFX/warningAlert.mp3");

    public Warning (float posX) : base(Settings.ASSET_PATH + "/Art/Warning.png",2,1)
        {
        WarningSound.Play(volume:0.3f);
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

