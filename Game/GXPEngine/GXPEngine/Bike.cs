﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Bike : AnimationSprite
{
    //Fixes the attack speed.
    private float attackSpeed = 35;
    private float bikeHealth = 10;
    private float fbiSpeed;

    public float bikeX;
    public float bikeY;
    float shootTime;

    bool hasStoped = false;

    Sound shot = new Sound(Settings.ASSET_PATH + "SFX/gunshotEnemy.mp3");
    Sound policeSirens = new Sound(Settings.ASSET_PATH + "SFX/policeSirens.mp3");

    EnemyBullet bullet;

    public Bike(float posX, float posY) : base(Settings.ASSET_PATH + "/Art/SmallCop.png", 6, 2, 20)
    {
        //SetOrigin(width / 2.0f, height / 2.0f);
        //rotation = 45;
        policeSirens.Play(volume: 0.15f);
        Random rnd = new Random();
        fbiSpeed = rnd.Next(4, 16);
        this.x = posX;
        this.y = posY;
        bikeX = this.x;
        bikeY = this.y;
        SetCycle(1, 9);

    }

    void Update()
    {
        if(GameManager.gameRunning)
        {

            Animate();

            if (shootTime % attackSpeed == 0)
            {
                    shot.Play(volume: 0.15f);
                    attack();
            }
            shootTime++;

            if (this.y >= 800)
            {
                this.y -= fbiSpeed;
                hasStoped = true;
            }

            copDeath();

        }
    }

    void OnCollision(GameObject obj)
    {
        if (obj is PlayerBullet)
        {
            bikeHealth = bikeHealth - PlayerBullet.bulletDamage;
        }
    }

    void attack()
    {
        bullet = new EnemyBullet(this.x + 70f, this.y + 50f, 15);

        if (hasStoped)
        {
            Game.main.AddChild(bullet);
        }
    }

    void copDeath()
    {
        if (bikeHealth <= 0)
        {
            LateDestroy();
            HUD.SCORE += 50;
            WaveBuilder.remainingEnemiesIntheWaves -= 1;
        }
    }
}