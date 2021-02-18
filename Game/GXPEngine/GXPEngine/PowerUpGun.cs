using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
    public class PowerUpGun : Sprite
    {
        float speed = 3f;
        private float timeStart;

        public PowerUpGun(float posX) : base(Settings.ASSET_PATH + "Art/PowerUpGun.png")
        {
            this.x = posX;
            this.y = -600;
        }

        void Update()
        {
            movement();
            DestroyThis();
        }

        void OnCollision(GameObject obj)
        {
        if (obj is Player)
            {
                MyGame.player.attackSpeed = 10;               
                LateDestroy();             
            }
        }

        void movement()
        {
            this.y += speed;
        }

    void DestroyThis()
    {
        if (this.y > game.height + 500)
        {
            LateDestroy();
        }
    }

}
