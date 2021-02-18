using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class PowerUpShield : Sprite
{
    float speed = 3f;
    float timeStart = 0;


    public PowerUpShield(float posX) : base(Settings.ASSET_PATH + "Art/PowerUpShield.png")
    {
        this.x = posX;
        this.y = -600;
    }

    void Update()
    {
        Console.WriteLine(timeStart);
        movement();
        DestroyThis();
    }

    void OnCollision(GameObject obj)
    {
        if (obj is Player)
        {
            
            LateDestroy();
        }
    }

    void movement()
    {
        this.y += speed;
    }

    void DestroyThis()
    {
        if (this.y > game.height + 500)
        {
            LateDestroy();
        }
    }

}