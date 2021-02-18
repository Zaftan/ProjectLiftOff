using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Sheriff : AnimationSprite
{
    //Fixes the attack speed.
    private float attackSpeed = 65;
    static public float sheriffHealth = 150;
    private float sheriffSpeed;

    public float copX;
    public float copY;
    float shootTime;

    bool hasStoped = false;

    float spreadRange = 50f;
    EnemyBullet bullet, bullet2, bullet3, bullet4, bullet5;

    Sound Entry = new Sound(Settings.ASSET_PATH + "SFX/bossEntersStage.mp3");
    Sound Laugh = new Sound(Settings.ASSET_PATH + "SFX/sheriffLaugh.mp3");
    public Sheriff(float posX, float posY) : base(Settings.ASSET_PATH + "/Art/Sheriff.png", 6, 2, 255)
    {
        //SetOrigin(width / 2.0f, height / 2.0f);
        //rotation = 45;

        Entry.Play(volume:0.8f);
        Laugh.Play(volume: 0.6f);
        Random rnd = new Random();
        sheriffSpeed = rnd.Next(4, 16);
        this.x = posX;
        this.y = posY;
        copX = this.x;
        copY = this.y;
        SetCycle(1, 9);
    }

    void Update()
    {
        if (GameManager.gameRunning)
        {
            Animate();        

            if (shootTime % attackSpeed == 0)
            {
                attack();
            }
            shootTime++;

            if (this.y >= 750) 
            {
                this.y -= sheriffSpeed;
                hasStoped = true;
            }

            copDeath();
        }
    }

    void OnCollision(GameObject obj)
    {
        if (obj is PlayerBullet)
        {
            sheriffHealth = sheriffHealth - PlayerBullet.bulletDamage;
        }
    }

    void attack()
    {
        bullet = new EnemyBullet(this.x + 70f + spreadRange - 80, this.y + 50f, 5);
        bullet2 = new EnemyBullet(this.x + 70f + spreadRange - 40, this.y + 50f, 5);
        bullet3 = new EnemyBullet(this.x + 70f + spreadRange, this.y + 50f, 5);
        bullet4 = new EnemyBullet(this.x + 70f + spreadRange + 40, this.y + 50f, 5);
        bullet5 = new EnemyBullet(this.x + 70f + spreadRange + 80, this.y + 50f, 5);

        if (hasStoped)
        {
            Game.main.AddChild(bullet);
            Game.main.AddChild(bullet2);
            Game.main.AddChild(bullet3);
            Game.main.AddChild(bullet4);
            Game.main.AddChild(bullet5);
        }
    }

    void copDeath()
    {
        if (sheriffHealth <= 0)
        {
            LateDestroy();
            HUD.SCORE += 500;
            WaveBuilder.remainingEnemiesIntheWaves -= 1;
        }
    }
}