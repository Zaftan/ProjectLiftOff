using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class FBI : AnimationSprite
{
    //Fixes the attack speed.
    private float attackSpeed = 100;
    private float fbiHealth = 60;
    private float fbiSpeed;

    public float fbiX;
    public float fbiY;
    float shootTime;

    bool hasStoped = false;
    
    EnemyBullet bullet;

    public FBI(float posX, float posY) : base(Settings.ASSET_PATH + "/Art/BigCop.png", 5, 2, 20)
    {
        //SetOrigin(width / 2.0f, height / 2.0f);
        //rotation = 45;
        Random rnd = new Random();
        fbiSpeed = rnd.Next(4, 16);
        this.x = posX;
        this.y = posY;
        fbiX = this.x;
        fbiY = this.y;
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
            this.y -= fbiSpeed;
            hasStoped = true;
        }

        copDeath();
        Console.WriteLine("Enemys left:" + WaveBuilder.remainingEnemiesIntheWaves);
    }

    void OnCollision(GameObject obj)
    {
        if (obj is PlayerBullet)
        {
            fbiHealth = fbiHealth - PlayerBullet.bulletDamage;
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
        if (fbiHealth <= 0)
        {
            LateDestroy();
            HUD.SCORE += 50;
            WaveBuilder.remainingEnemiesIntheWaves -= 1;
        }
    }
}