using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

public class HUD : Canvas
{
    Player player;

    Font font = new Font("Arial", 20);

    static public float SCORE = 0;

     public HUD() : base(400, 300, addCollider: false)
    {
        player = new Player();
    }
    void Update()
    {
        showHud();
    }

    //Draws the strings onto the screen.
    void showHud()
    {
        string score = "Score: " + SCORE;
        string health = "Health: " + player.getHealth();
        graphics.Clear(Color.Empty);
        graphics.DrawString(score, font, Brushes.Black, 30, 30);
        graphics.DrawString(health, font, Brushes.Black, 200, 30);
    }
}
