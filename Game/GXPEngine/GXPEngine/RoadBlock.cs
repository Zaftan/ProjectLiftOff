using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    public class RoadBlock : Sprite
    {
        float speed = 3f;
        static public float blockDamage = 30f;


        public RoadBlock(float posX, float posY) : base(Settings.ASSET_PATH + "Art/SpikeTrap.png")
        {
        this.x = posX;
        this.y = posY;
    }

        void Update()
        {
        movement();
        }

        void OnCollision(GameObject obj)
        {
            if (obj is Player)
            {
                LateDestroy();
            }
        }

    void movement()
        {
        this.y+= 4f;
        }


    }

