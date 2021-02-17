using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Player : AnimationSprite
{
    PlayerBullet bullet;

    float shootTime;

    public float playerHealth = 100f;
    private float attackSpeed = 25;
    float posX = 850f;
    float posY = 350f;
    float speed = 4;

    bool canMoveLeft, canMoveRight = true;

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
        if(shootTime % attackSpeed == 0)
        {
            attack();
        }
        shootTime++;
    }

    void OnCollision(GameObject obj)
    {
        if (obj is EnemyBullet)
        {
            playerHealth = playerHealth - EnemyBullet.bulletDamage;
        }

        if (obj is RoadBlock)
        {
            playerHealth = playerHealth - RoadBlock.blockDamage;
        }
    }

    void movement()
    {
        posX = 0;
        
        if (Input.GetKey(Key.A) && canMoveLeft)
        {
            this.rotation = -5;
            posX -= speed;
        }
        else if (Input.GetKey(Key.D) && canMoveRight)
        {
            this.rotation = 5;
            posX += speed;
        }
        else
        {
            this.rotation = 0;
        }

        if(this.x <= 400)
        {
            canMoveLeft = false;
        }
        else if(this.x >= 1435)
        {
            canMoveRight = false;
        }
        else
        {
            canMoveLeft = true;
            canMoveRight = true;
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