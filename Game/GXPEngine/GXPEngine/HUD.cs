using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

public class HUD : Canvas
{
    Font font = new Font("Arial", 18);
    Font font2 = new Font("Arial", 45);
    Pen pen = new Pen(Brushes.DarkRed, 8);
    static public float SCORE;
    



    public HUD() : base(Game.main.width, Game.main.height, addCollider: false)
    {
        //
    }
    void Update()
    {
        string score2 = "Score: " + SCORE;
        showHud();
        showBossHP();
        ScoreM();
        if (GameManager.gameRunning == false)
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString(score2, font2, Brushes.White, 850, 750);

        }
    }

    //Draws the strings onto the screen.
    void showHud()
    {
        string score = "Score: " + SCORE;
        string health = "" + MyGame.player.getHealth();
        graphics.Clear(Color.Empty);
        graphics.DrawRectangle(pen, 400, 100, 200, 30);
        graphics.FillRectangle(Brushes.Black, 400, 100, 200, 30);
        graphics.FillRectangle(Brushes.Red, 400,100,MyGame.player.playerHealth * 2, 30);
        graphics.DrawString(health, font, Brushes.White, 482, 102);
        graphics.DrawString(score, font, Brushes.White, 1400, 100);
    }


    void showBossHP()
    {
        if (WaveBuilder.waves == 11)
        {
            graphics.DrawRectangle(pen, 800, 100, 300, 30);
            graphics.FillRectangle(Brushes.Black, 800, 100, 300, 30);
            graphics.FillRectangle(Brushes.Red, 800, 100, Sheriff.sheriffHealth * 2, 30);
        }

        if (Sheriff.sheriffHealth <= 0)
        {
            graphics.Clear(Color.Empty);
        }

    }

    void ScoreM()
    {
        if(SCORE < 0)
        {
            SCORE = 0;
        }
    }
}
