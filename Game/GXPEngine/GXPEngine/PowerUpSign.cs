using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class PowerUpSign : AnimationSprite
{

    public PowerUpSign(float posX) : base(Settings.ASSET_PATH + "/Art/PowerUpSign.png", 2, 1)
    {
        this.x = posX;
        this.y = 150f;
    }

    void OnCollision(GameObject obj)
    {
        if (obj is PowerUpGun)
        {
            LateDestroy();
        }

        if (obj is PowerUpLife)
        {
            LateDestroy();
        }

        if (obj is PowerUpShield)
        {
            LateDestroy();
        }
    }

    void Update()
    {
        Animate();
    }


}