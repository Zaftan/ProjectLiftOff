using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    class Smoke : Sprite
    {
    private float roadstart;
    private float scrollSpeed = 7.5f;
    private float spriteScrolled;

    public Smoke() : base(Settings.ASSET_PATH + "Art/BackgroundSmoke.png", addCollider: false)
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

