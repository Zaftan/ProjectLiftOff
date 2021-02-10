using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Background : AnimationSprite
{
    public Background() : base(Settings.ASSET_PATH + "Art/Road.gif", 1, 1, addCollider: false)
    {
        SetOrigin(-300, -80);
    }
}