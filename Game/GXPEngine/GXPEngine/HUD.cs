using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

public class HUD : Canvas
{
    Font font = new Font("Arial", 18);
    Pen pen = new Pen(Brushes.DarkRed, 8);
    static public float SCORE = 0;

    public HUD() : base(Game.main.width, 400, addCollider: false)
    {
        //
    }
    void Update()
    {
        showHud();
    }

    //Draws the strings onto the screen.
    void showHud()
    {
        string score = "Score: " + SCORE;
        string health = ""+MyGame.player.getHealth();
        graphics.Clear(Color.Empty);
        graphics.DrawRectangle(pen, 400, 100, 200, 30);
        graphics.FillRectangle(Brushes.Black, 400, 100, 200, 30);
        graphics.FillRectangle(Brushes.Red, 400,100,MyGame.player.playerHealth * 2, 30);
        graphics.DrawString(health, font, Brushes.White, 482, 102);
        graphics.DrawString(score, font, Brushes.White, 1400, 100);
    }
}
