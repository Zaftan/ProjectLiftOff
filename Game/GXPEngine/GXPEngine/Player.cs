﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;

public class Player : AnimationSprite
{
    PlayerBullet bullet;
    

    float shootTime;

    public float playerHealth = 100f;
    public float attackSpeed = 25;
    float posX = 850f;
    float posY = 350f;
    float speed = 4;
    float timeStart;
    float timeStart2;
    public float curHP;

    bool canMoveLeft, canMoveRight = true;
    public bool Invulnerability = false;

    Sound shot = new Sound(Settings.ASSET_PATH + "SFX/gunshotPlayer.mp3");
    Sound LifePickUp = new Sound(Settings.ASSET_PATH + "SFX/healthPickUp.mp3");
    Sound ShieldPickUp = new Sound(Settings.ASSET_PATH + "SFX/shieldPickup.mp3");
    Sound GunPickUp = new Sound(Settings.ASSET_PATH + "SFX/machineGunPickup.mp3");
    Sound TirePop = new Sound(Settings.ASSET_PATH + "SFX/tirePop.mp3");

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
        CollisionFix();
        Health();
        //Fixes the attack speed.
        if (shootTime % attackSpeed == 0)
        {          
            attack();
        }
        shootTime++;
        SetCycle(1, 19, 7);

        Timer();
        Timer2();
        
    }

    void OnCollision(GameObject obj)
    {
        if (obj is EnemyBullet)
        {
            EnemyBullet eb = (EnemyBullet) obj;
            if (!eb.hit)
            {
                HUD.SCORE -= 25;
                playerHealth = playerHealth - EnemyBullet.bulletDamage;
                obj.LateDestroy();
                eb.hit = true;
                SetCycle(20, 2, 255);
            }
        }

        if (obj is RoadBlock)
        {
            HUD.SCORE -= 50;
            TirePop.Play(volume: 0.3f);
            playerHealth = playerHealth - RoadBlock.blockDamage;
            obj.LateDestroy();
            SetCycle(20, 2, 255);
        }

        if (obj is PowerUpGun)
        {
            GunPickUp.Play(volume: 0.3f);
            timeStart = Time.time;
            PowerUpAnimationG pag = new PowerUpAnimationG();
            Game.main.LateAddChild(pag);
            obj.LateDestroy();
        }

        if (obj is PowerUpShield)
        {
            ShieldPickUp.Play(volume: 0.3f);
            PowerUpAnimationS pas = new PowerUpAnimationS();
            Game.main.LateAddChild(pas);
            curHP = playerHealth;
            timeStart2 = Time.time;
            Invulnerability = true;
            obj.LateDestroy();
        }

        if (obj is PowerUpLife)
        {
            LifePickUp.Play(volume: 0.3f);
            PowerUpAnimationL pal = new PowerUpAnimationL();
            Game.main.LateAddChild(pal);
        }
    }

    void CollisionFix()
    {
        Collision cobj = MoveUntilCollision(posX, 0);

        if (cobj != null && cobj.other is EnemyBullet)
        {

            EnemyBullet eb = (EnemyBullet) cobj.other;
            if (!eb.hit)
            {
                HUD.SCORE -= 25;
                playerHealth = playerHealth - EnemyBullet.bulletDamage;
                cobj.other.LateDestroy();
                eb.hit = true;
                SetCycle(20, 2, 255);
            }
        }

        if (cobj != null && cobj.other is RoadBlock)
        {
            HUD.SCORE -= 50;
            TirePop.Play(volume: 0.3f);
            playerHealth = playerHealth - RoadBlock.blockDamage;
            cobj.other.LateDestroy();
            SetCycle(20, 2, 255);
        }

        if (cobj != null && cobj.other is PowerUpGun)
        {
            GunPickUp.Play(volume: 0.3f);
            timeStart = Time.time;
            PowerUpAnimationG pag = new PowerUpAnimationG();
            Game.main.LateAddChild(pag);
            attackSpeed = 10;
            cobj.other.LateDestroy();
        }

        if (cobj != null && cobj.other is PowerUpLife)
        {
            LifePickUp.Play(volume: 0.3f);
            curHP = curHP + 50;
            playerHealth = playerHealth + 50;
            PowerUpAnimationL pal = new PowerUpAnimationL();
            Game.main.LateAddChild(pal);
            cobj.other.LateDestroy();
        }

        if (cobj != null && cobj.other is PowerUpShield)
        {
            ShieldPickUp.Play(volume: 0.3f);
            curHP = playerHealth;
            timeStart2 = Time.time;
            Invulnerability = true;
            cobj.other.LateDestroy();
            PowerUpAnimationS pas = new PowerUpAnimationS();
            Game.main.LateAddChild(pas);
        }
    }

    void Timer()
    {
        if (Time.time > timeStart + 10000)
        {
            attackSpeed = 25;
        }
    }

    void Timer2()
    {
        if (Time.time > timeStart2 + 5000)
        {
            Invulnerability = false;
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
    }

    void attack()
    {
        bullet = new PlayerBullet();

        //Shoots if the mouse is bellow the horizontal axis. 
        if (Input.mouseY > Game.main.height / 2 + 100)
        {           
            if (Input.GetMouseButton(0))
            {
                shot.Play(volume: 0.3f);
                Game.main.AddChild(bullet);
                //new Sound(Settings.ASSET_PATH + "SFX/Sans.mp3").Play();                            
            }
        }
    }

    void Health()
    {
        if(playerHealth > 100)
        {
            playerHealth = 100;
        }

        if (curHP > 100)
        {
            curHP = 100;
        }

        if (Invulnerability)
        {
            playerHealth = curHP;
        }
    }

    public float getHealth()
    {
        return playerHealth;
    }
}
