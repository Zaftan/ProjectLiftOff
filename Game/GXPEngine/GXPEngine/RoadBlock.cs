using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    public class RoadBlock : Sprite
    {
        float speed = 10f;
        static public float blockDamage = 30f;


        public RoadBlock(float posX) : base(Settings.ASSET_PATH + "Art/SpikeTrap.png")
        {
        this.x = posX;
        this.y = - 1000;
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
                LateDestroy();
            }
        }

    void movement()
        {
        this.y+= speed;
        }

    void DestroyThis()
    {
        if( this.y > game.height + 500)
        {
            LateDestroy();
        }
    }


    }

