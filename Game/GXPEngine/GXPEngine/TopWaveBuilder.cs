﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class TopWaveBuilder
{
    static public float counter;
    private int waves = 1;
    public Random rnd;
    int randon;

    public TopWaveBuilder()
    {
        rnd = new Random();
    }

    public void Update()
    {
        counter++;
        Console.WriteLine("" + counter);
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
        waves = rnd.Next(1, 6);
    }

    public void CountDown()
    {
        if (counter % 600 == 0)
        {
            WaveSpawner();
        }
    }

    private void wave1()
    {
        RoadBlock RB = new RoadBlock(387, -600);
        Warning WR = new Warning(450, 100);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave2()
    {
        RoadBlock RB = new RoadBlock(603, -600);
        Warning WR = new Warning(670, 100);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave3()
    {
        RoadBlock RB = new RoadBlock(821, -600);
        Warning WR = new Warning(890, 100);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave4()
    {
        RoadBlock RB = new RoadBlock(1037, -600);
        Warning WR = new Warning(1100, 100);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave5()
    {
        RoadBlock RB = new RoadBlock(1247, -600);
        Warning WR = new Warning(1320, 100);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }
}