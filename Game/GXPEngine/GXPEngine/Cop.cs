using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Cop : Sprite
{
    private float copHealth = 50;
    private float copSpeed;
    
    public Cop(float posX, float posY) : base(Settings.ASSET_PATH + "/Art/Cop.png")
    {
        //SetOrigin(width / 2.0f, height / 2.0f);
        //rotation = 45;
        Random rnd = new Random();
        copSpeed = rnd.Next(4, 16);
        this.x = posX;
        this.y = posY;
    }

    void Update()
    {
        if (this.y >= 700)
        {
            this.y -= copSpeed;
        }
        //this.x++; //posX++;
        //MyGame.builder.CountDown();
        copDeath();
        Console.WriteLine("Enemys left:" + WaveBuilder.remainingEnemiesIntheWaves);
    }

    void OnCollision(GameObject obj)
    {
        if (obj is PlayerBullet)
        {
            copHealth = copHealth - PlayerBullet.bulletDamage;
        }
    }

    void copDeath()
    {
        if (copHealth <= 0)
        {
            LateDestroy();
            HUD.SCORE += 10;
            WaveBuilder.remainingEnemiesIntheWaves -= 1;
        }
    }
}