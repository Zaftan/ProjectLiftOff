using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class WaveBuilder
{
    static public float remainingEnemiesIntheWaves;
    private int waves = 0;

    public WaveBuilder()
    {
        //
    }

    public void WaveSpawner()
    {
        switch (waves)
        {
            case 0: wave0(); break;
            case 1: wave1(); break;
            case 2: wave2(); break;
            case 3: wave3(); break;
            case 4: wave4(); break;
            case 5: wave5(); break;
            case 6: wave6(); break;
            case 7: wave7(); break;
            case 8: wave8(); break;
            case 9: wave9(); break;
            case 10: wave10(); break;

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

    private void wave0()
    {
        remainingEnemiesIntheWaves = 0;
    }

    private void wave1()
    {
        Cop cop = new Cop(860f, 1200f);
        Game.main.LateAddChild(cop);
        remainingEnemiesIntheWaves = 1;
    }

    private void wave2()
    {
        Cop cop = new Cop(440f, 1200f);
        Cop cop2 = new Cop(1290f, 1200f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(cop2);
        remainingEnemiesIntheWaves = 2;
    }

    private void wave3()
    {
        Cop cop = new Cop(650f, 1200f);
        Cop cop2 = new Cop(860f, 1200f);
        Cop cop3 = new Cop(1070f, 1200f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(cop2);
        Game.main.LateAddChild(cop3);
        remainingEnemiesIntheWaves = 3;
    }

    private void wave4()
    {
        Bike bike = new Bike(650f, 1200f);
        Cop cop = new Cop(1290f, 1200f);
        Game.main.LateAddChild(bike);
        Game.main.LateAddChild(cop);
        remainingEnemiesIntheWaves = 2;
    }

    private void wave5()
    {
        Bike bike1 = new Bike(650f, 1200f);
        Cop cop = new Cop(860f, 1200f);
        Bike bike2 = new Bike(1070f, 1200f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(bike1);
        Game.main.LateAddChild(bike2);
        remainingEnemiesIntheWaves = 3;
    }

    private void wave6()
    {
        FBI fbi = new FBI(860f, 1200f);
        Game.main.LateAddChild(fbi);
        remainingEnemiesIntheWaves = 1;
    }
    
    private void wave7()
    {
        Cop cop = new Cop(440f, 1200f);
        Cop cop1 = new Cop(650f, 1200f);
        FBI fbi = new FBI(1290, 1200f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(cop1);
        Game.main.LateAddChild(fbi);
        remainingEnemiesIntheWaves = 3;
    }

    private void wave8()
    {
        FBI fbi = new FBI(650f, 1200f);
        Bike bike = new Bike(860f, 1200f);
        FBI fbi1 = new FBI(1070f, 1200f);
        Game.main.LateAddChild(fbi);
        Game.main.LateAddChild(bike);
        Game.main.LateAddChild(fbi1);
        remainingEnemiesIntheWaves = 3;
    }

    private void wave9()
    {
        Bike bike = new Bike(440f, 1200f);
        FBI fbi = new FBI(650f, 1200f);
        Cop cop = new Cop(860f, 1200f);
        FBI fbi2 = new FBI(1070f, 1200f);
        Bike bike2 = new Bike(1290f, 1200f);
        Game.main.LateAddChild(fbi);
        Game.main.LateAddChild(bike);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(bike2);
        Game.main.LateAddChild(fbi2);
        remainingEnemiesIntheWaves = 5;
    }

    private void wave10()
    {
        Sheriff sheriff = new Sheriff(860f, 1300f);
        Game.main.LateAddChild(sheriff);
        remainingEnemiesIntheWaves = 1;
    }
}