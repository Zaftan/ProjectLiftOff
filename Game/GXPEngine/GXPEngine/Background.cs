using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Background : AnimationSprite
{
    private float roadstart, roadStart;
    private float scrollSpeed = 15f;
    private float spriteHeight, spriteScrolled;

    public Background() : base(Settings.ASSET_PATH + "Art/Road.png", 1, 1, addCollider: false)
    {
        spriteHeight = this.height;
        roadstart = this.height - 1080;
        roadStart = this.height - 1080;


        this.y+= scrollSpeed;
    }

    void Update()
    {
        SetOrigin(-300, roadstart);
        spriteScrolled = roadstart -= scrollSpeed;

        spriteScrolled = spriteScrolled -= 1080;
        if (spriteHeight == spriteScrolled)
        {
            this.y = roadStart;
            //(this.y == -80)
            //if sprite height = roadstart+=scrollspeed
            //add new background remove old background
        }
    }
}