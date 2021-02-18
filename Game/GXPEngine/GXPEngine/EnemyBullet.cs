using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class EnemyBullet : AnimationSprite
{
    static public float bulletDamage;
    private float bulletSpeed = 3f;

    /*Sets the target coordinates for where the bullet is being shot at*/
    private float targetX = MyGame.player.x;
    private float targetY = MyGame.player.y;

    private float dirX;
    private float dirY;

    public bool hit = false;

    Sound HitPlayer = new Sound(Settings.ASSET_PATH + "SFX/bulletHitPlayer.mp3");
    Sound HitPlayerShield = new Sound(Settings.ASSET_PATH + "SFX/bulletHitShield.mp3");

    public EnemyBullet(float shootPointX, float shootPointY, float bulletDmg) : base(Settings.ASSET_PATH + "Art/EnemyBullet.png",2,1,255)
    {
        this.x = shootPointX;
        this.y = shootPointY;
        SetCycle(0,1);

        dirX = targetX - shootPointX;
        dirY = targetY - shootPointY;

        float mag = Mathf.Sqrt(dirX * dirX + dirY * dirY);
        bulletDamage = bulletDmg;

        dirX /= mag;
        dirY /= mag;
    }

    void Update()
    {
        SetCycle(1,2);
        Animate();
        BulletTarget();
        BulletDestroy();
    }

    //Function for the bullet path and where it should go.
    void BulletTarget()
    {
        x += dirX * bulletSpeed;
        y += dirY * bulletSpeed;
        //MoveUntilCollision(dirX * bulletSpeed, dirY * bulletSpeed);
    }

    //Destroys the bullet when getting out of screen.
    void BulletDestroy()
    {
        if (x > Game.main.width || x < 0 - width || y < 0 - height)
        {
            LateDestroy();
            //Console.WriteLine("Bullet Destroyed");
        }
    }
    void OnCollision(GameObject obj)
    {
        if (obj is Player)
        {
            
            LateDestroy();
            if (MyGame.player.Invulnerability)
            {
                HitPlayerShield.Play(volume: 0.2f);
            }
            else
            {
                HitPlayer.Play(volume: 0.2f);
            }
        }

        if (obj is Border)
        {
            LateDestroy();
        }

        if (obj is PlayerBullet)
        {
            LateDestroy();
        }
    }
}