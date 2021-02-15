using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class EnemyBullet : Sprite
{
    static public float bulletDamage = 5;
    private float bulletSpeed = 3f;

    /*Sets the target coordinates for where the bullet is being shot at*/
    private float targetX = MyGame.player.x;
    private float targetY = MyGame.player.y;

    private float dirX;
    private float dirY;

    public EnemyBullet(float shootPointX, float shootPointY) : base(Settings.ASSET_PATH + "Art/EnemyBullet.png")
    {
        this.x = shootPointX;
        this.y = shootPointY;

        dirX = targetX - shootPointX;
        dirY = targetY - shootPointY;

        float mag = Mathf.Sqrt(dirX * dirX + dirY * dirY);

        dirX /= mag;
        dirY /= mag;
    }

    void Update()
    {
        BulletTarget();
        BulletDestroy();
    }

    //Function for the bullet path and where it should go.
    void BulletTarget()
    {
        x += dirX * bulletSpeed;
        y += dirY * bulletSpeed;
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