using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Player : Sprite
{
    PlayerBullet bullet;

    float shootTime;

    float playerHealth = 100f;

    float posX = 450f;
    float posY = 100f;
    float speed = 4;

    public Player() : base(Settings.ASSET_PATH + "Art/Player.png")
    {
        this.x = posX;
        this.y = posY;
    }

    void Update()
    {
        movement();

        if(shootTime % 30 == 0)
        {
            attack();
        }
        shootTime++;
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
        bullet = new PlayerBullet();

        //Shoots if the mouse is bellow the horizontal axis. 
        if (Input.mouseY > Game.main.height/2)
        {           
                if (Input.GetMouseButton(0))
                    {              
                          Game.main.AddChild(bullet);

                          new Sound(Settings.ASSET_PATH + "SFX/Sans.mp3").Play();                            
                    }
        }
    }
}