using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Border : AnimationSprite
{
    public Border() : base(Settings.ASSET_PATH + "Art/Border.png", 1, 1, addCollider: false)
    {
        //
    }
}