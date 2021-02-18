using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class PlayerBullet : AnimationSprite
{
    static public float bulletDamage = 10;
    private float bulletSpeed = 10f;

    /*Sets the target coordinates for where the bullet is being shot at*/
    private float targetX = Input.mouseX;
    private float targetY = Input.mouseY;

    /*Sets the target coordinates for where the bullet is being shot from*/
    private float shootPointX = MyGame.player.x - 15f;
    private float shootPointY = MyGame.player.y + 105f;

    private float dirX;
    private float dirY;

    Sound HitEnemy = new Sound(Settings.ASSET_PATH + "SFX/bulletHitEnemy.mp3");

    public PlayerBullet() : base(Settings.ASSET_PATH + "Art/PlayerBullet.png",2, 1, 255)
    {
        this.x = shootPointX;
        this.y = shootPointY;

        dirX = targetX - shootPointX;
        dirY = targetY - shootPointY;

        float mag = Mathf.Sqrt(dirX * dirX + dirY * dirY);

        dirX /= mag;
        dirY /= mag;

        SetCycle(0,1);
    }

    void Update()
    {
        SetCycle(1, 2);
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
        if (x > Game.main.width || x < 0 - width || y > Game.main.height)
        {
            LateDestroy();
            //Console.WriteLine("Bullet Destroyed");
        }
    }
    void OnCollision(GameObject obj)
    {
        if (obj is Cop)
        {
            HitEnemy.Play(volume: 0.1f);
            LateDestroy();
        }

        if (obj is FBI)
        {
            HitEnemy.Play(volume: 0.1f);
            LateDestroy();
        }
        
        if (obj is Bike)
        {
            HitEnemy.Play(volume: 0.1f);
            LateDestroy();
        }

        if (obj is Sheriff)
        {
            HitEnemy.Play(volume: 0.1f);
            LateDestroy();
        }

        if (obj is Border)
        {
            LateDestroy();
        }

        if (obj is EnemyBullet)
        {
            LateDestroy();

        }
    }
}
