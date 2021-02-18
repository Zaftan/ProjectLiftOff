using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Lights : Sprite
{
    private float roadstart;
    private float scrollSpeed = 10f;
    private float spriteScrolled;

    public Lights() : base(Settings.ASSET_PATH + "Art/BackgroundLight.png", addCollider: false)
    {
        roadstart = this.height - 1080;
        this.y += scrollSpeed;
    }

    void Update()
    {
        SetOrigin(-300, roadstart);
        spriteScrolled = roadstart -= scrollSpeed;

        if (spriteScrolled <= -200)
        {
            this.y = roadstart;
            roadstart = this.height - 1280;
        }
    }
}