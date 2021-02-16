using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class WaveBuilder
{
    static public float remainingEnemiesIntheWaves;
    private int waves = 1;

    public WaveBuilder()
    {
        //
    }

    public void WaveSpawner()
    {
        switch (waves)
        {
            case 1: wave1(); break;
            case 2: wave2(); break;
            case 3: wave3(); break;
            case 4: wave4(); break;
            case 5: wave5(); break;
        }
        waves++;
    }

    public void CountDown()
    {
        if (remainingEnemiesIntheWaves == 0)
        {
            WaveSpawner();
        }
    }

    private void wave1()
    {
        Cop cop = new Cop(440f, 1200f);
        Game.main.LateAddChild(cop);
        remainingEnemiesIntheWaves = 1;
    }

    private void wave2()
    {
        Cop cop = new Cop(440f, 1200f);
        Bike bike = new Bike(650f, 1200f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(bike);
        remainingEnemiesIntheWaves = 2;
    }

    private void wave3()
    {
        Cop cop = new Cop(440f, 1200f);
        FBI fbi = new FBI(650f, 1200f);
        Cop cop3 = new Cop(860f, 1200f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(fbi);
        Game.main.LateAddChild(cop3);
        remainingEnemiesIntheWaves = 3;
    }

    private void wave4()
    {
        Cop cop = new Cop(440f, 1200f);
        Cop cop2 = new Cop(650f, 1200f);
        Cop cop3 = new Cop(860f, 1200f);
        Cop cop4 = new Cop(1070f, 1200f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(cop2);
        Game.main.LateAddChild(cop3);
        Game.main.LateAddChild(cop4);
        remainingEnemiesIntheWaves = 4;
    }

    private void wave5()
    {
        Cop cop = new Cop(440f, 1200f);
        Cop cop2 = new Cop(650f, 1200f);
        Cop cop3 = new Cop(860f, 1200f);
        Cop cop4 = new Cop(1070f, 1200f);
        Cop cop5 = new Cop(1290f, 1200f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(cop2);
        Game.main.LateAddChild(cop3);
        Game.main.LateAddChild(cop4);
        Game.main.LateAddChild(cop5);
        remainingEnemiesIntheWaves = 5;
    }
}