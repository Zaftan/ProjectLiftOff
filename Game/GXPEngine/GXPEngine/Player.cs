using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Player : Sprite
{
    float posX = 450f;
    float posY = 300f;
    float speed = 5;

    public Player() : base(Settings.ASSET_PATH + "Art/Player.png")
    {
        this.x = posX;
        this.y = posY = 300f;
    }

    void Update()
    {
        movement();
    }

    void movement()
    {
        posX = 0;

        if (Input.GetKey(Key.A))
        {
            posX -= speed;
        }
        else if (Input.GetKey(Key.D))
        {
            posX += speed;
        }

        MoveUntilCollision(posX, 0);
    }

    void attack()
    {
        if (Input.GetKey(Key.S))
        {
            //
        }
        //on LEFT_CLICK create BULLET; BULLET = SPAWN_POS - ROADSPEED
        //new Sound("ping.wav").Play();
    }
}