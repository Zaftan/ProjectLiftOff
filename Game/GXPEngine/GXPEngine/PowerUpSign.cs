using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class PowerUpSign : AnimationSprite
{
    Sound WarningSound = new Sound(Settings.ASSET_PATH + "SFX/warningAlert.mp3");
    public PowerUpSign(float posX) : base(Settings.ASSET_PATH + "/Art/PowerUpSign.png", 2, 1)
    {
        WarningSound.Play(volume: 0.3f);
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