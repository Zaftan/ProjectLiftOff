using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
   public class PowerUpLife : Sprite
    {
        public float healthRestored = 50;
        float speed = 3f;
       public PowerUpLife(float posX) : base(Settings.ASSET_PATH + "Art/PowerUpLife.png")
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
                MyGame.player.playerHealth += healthRestored;
                MyGame.player.curHP += healthRestored;
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
