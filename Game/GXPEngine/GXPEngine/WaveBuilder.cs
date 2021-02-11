using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class WaveBuilder
{
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
        }
        waves++;
    }
    private float remainingEnemiesIntheWaves;

    public void CountDown()
    {
        if (--remainingEnemiesIntheWaves <= 0)
        {
            WaveSpawner();
        }
    }

    private void wave1()
    {
        Cop cop = new Cop(450f, 700f);
        Game.main.LateAddChild(cop);
        remainingEnemiesIntheWaves = 1;
    }

    private void wave2()
    {
        Cop cop = new Cop(450f, 700f);
        Cop cop2 = new Cop(750f, 700f);
        Game.main.LateAddChild(cop);
        Game.main.LateAddChild(cop2);
        remainingEnemiesIntheWaves = 2;
    }
}