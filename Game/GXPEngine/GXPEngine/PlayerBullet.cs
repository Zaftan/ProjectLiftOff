using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class PlayerBullet : Sprite
{
    private float bulletDamage = 5f;
    private float bulletSpeed = 10f;

    /*Sets the target coordinates for where the bullet is being shot at*/
    private float targetX = Input.mouseX;
    private float targetY = Input.mouseY;

    /*Sets the target coordinates for where the bullet is being shot from*/
    private float shootPointX = MyGame.player.x + MyGame.player.width / 2;
    private float shootPointY = MyGame.player.y + MyGame.player.height + 5f;

    private float dirX;
    private float dirY;

    public PlayerBullet() : base(Settings.ASSET_PATH + "Art/PlayerBullet.png")
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
        if (x > Game.main.width || x < 0 - width || y > Game.main.height)
        {
            LateDestroy();
            Console.WriteLine("Bullet Destroyed"); 
        }
    }
}
