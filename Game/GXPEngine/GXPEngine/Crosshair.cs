using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


public class Crosshair : Sprite
{
    public Crosshair() : base(Settings.ASSET_PATH + "/Art/Crosshair.png", addCollider: false)
    {
    }

    void Update()
    {
        this.x = Input.mouseX - this.width / 2;
        this.y = Input.mouseY - this.height / 2;
    }

}

