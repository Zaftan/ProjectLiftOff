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
        Cop cop = new Cop(450f, 1300f);
        Game.main.LateAddChild(cop);
        remainingEnemiesIntheWaves = 1;
    }

    private void wave2()
    {
        Cop cop = new Cop(450f, 1300f);
        Cop cop2 = new Cop(750f, 1300f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(cop2);
        remainingEnemiesIntheWaves = 2;
    }

    private void wave3()
    {
        Cop cop = new Cop(450f, 1300f);
        Cop cop2 = new Cop(750f, 1300f);
        Cop cop3 = new Cop(1050f, 1300f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(cop2);
        Game.main.LateAddChild(cop3);
        remainingEnemiesIntheWaves = 3;
    }
}