using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Player : AnimationSprite
{
    PlayerBullet bullet;

    float shootTime;

    float playerHealth = 100f;

    float posX = 850f;
    float posY = 350f;
    float speed = 4;

    public Player() : base(Settings.ASSET_PATH + "Art/Player.png", 8, 3, 20)
    {
        SetOrigin(width / 2.0f, height / 2.0f);
        this.x = posX;
        this.y = posY;
    }

    void Update()
    {
        Animate();
        movement();
        //Fixes the attack speed.
        if(shootTime % 25 == 0)
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
            this.rotation = -5;
            posX -= speed;
        }
        else if (Input.GetKey(Key.D))
        {
            this.rotation = 5;
            posX += speed;
        }
        else
        {
            this.rotation = 0;
        }

        MoveUntilCollision(posX, 0);
    }

    void attack()
    {
        bullet = new PlayerBullet();

        //Shoots if the mouse is bellow the horizontal axis. 
        if (Input.mouseY > Game.main.height / 2)
        {           
            if (Input.GetMouseButton(0))
            {              
                Game.main.AddChild(bullet);
                //new Sound(Settings.ASSET_PATH + "SFX/Sans.mp3").Play();                            
            }
        }
    }

    public float getHealth()
    {
        return playerHealth;
    }
}