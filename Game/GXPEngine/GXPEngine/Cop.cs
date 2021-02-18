using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Cop : AnimationSprite
{
    //Fixes the attack speed.
    private float attackSpeed = 100;
    private float copHealth = 30;
    private float copSpeed;

    public float copX;
    public float copY;
    float shootTime;

    bool hasStoped = false;

    EnemyBullet bullet;

    public Cop(float posX, float posY) : base(Settings.ASSET_PATH + "/Art/Cop.png", 5, 3, 255)
    {
        //SetOrigin(width / 2.0f, height / 2.0f);
        //rotation = 45;
        Random rnd = new Random();
        copSpeed = rnd.Next(4, 16);
        this.x = posX;
        this.y = posY;
        copX = this.x;
        copY = this.y;
        SetCycle(1, 9);
    }

    void Update()
    {
        Animate();

        if (shootTime % attackSpeed == 0)
        {
            attack();
        }
        shootTime++;

        if (this.y >= 800)
        {
            this.y -= copSpeed;
            hasStoped = true;
        }
        
        copDeath();
    }

    void OnCollision(GameObject obj)
    {
        if (obj is PlayerBullet)
        {
            copHealth = copHealth - PlayerBullet.bulletDamage;
        }
    }

    void attack()
    {
        bullet = new EnemyBullet(this.x + 70f, this.y + 50f, 10);

        if (hasStoped)
        {
            Game.main.AddChild(bullet);
        }
    }

    void copDeath()
    {
        if (copHealth <= 0)
        {
            LateDestroy();
            HUD.SCORE += 50;
            WaveBuilder.remainingEnemiesIntheWaves -= 1;
        }
    }
}