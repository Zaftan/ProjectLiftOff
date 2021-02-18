using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class TopWaveBuilder
{
    static public float counter;
    private int waves;
    public Random rnd;

    public TopWaveBuilder()
    {
        rnd = new Random();
    }

    public void Update()
    {          
        if(GameManager.gameRunning)
        {
            counter++;
        }
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
            case 6: wave6(); break;
            case 7: wave7(); break;
            case 8: wave8(); break;
            case 9: wave9(); break;
            case 10: wave10(); break;


        }
        waves = rnd.Next(1, 8);
    }

    public void CountDown()
    {
        if (GameManager.gameRunning) 
        { 
            if (counter % 600 == 0)
            {
                WaveSpawner();
            }
        }
    }

    private void wave1()
    {
        RoadBlock RB = new RoadBlock(387);
        Warning WR = new Warning(410);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave2()
    {
        RoadBlock RB = new RoadBlock(603);
        Warning WR = new Warning(630);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave3()
    {
        RoadBlock RB = new RoadBlock(821);
        Warning WR = new Warning(850);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave4()
    {
        RoadBlock RB = new RoadBlock(1037);
        Warning WR = new Warning(1060);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave5()
    {
        RoadBlock RB = new RoadBlock(1247);
        Warning WR = new Warning(1280);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(WR);
    }

    private void wave6()
    {
        RoadBlock RB2 = new RoadBlock(1037);
        Warning WR2 = new Warning(1060);
        RoadBlock RB = new RoadBlock(1247);
        Warning WR = new Warning(1280);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);
    }

    private void wave7()
    {
        PowerUpLife pul = new PowerUpLife(435);
        Game.main.LateAddChild(pul);
    }

    private void wave8()
    {
        PowerUpGun pug = new PowerUpGun(435);
        Game.main.LateAddChild(pug);
    }

    private void wave9()
    {
        PowerUpShield pus = new PowerUpShield(650);
        Game.main.LateAddChild(pus);
    }

    private void wave10()
    {
        PowerUpShield pus = new PowerUpShield(435);
        Game.main.LateAddChild(pus);
        PowerUpLife pul2 = new PowerUpLife(650);
        Game.main.LateAddChild(pul2);
/*        PowerUpLife pul3 = new PowerUpLife(865);
        Game.main.LateAddChild(pul3);
        PowerUpLife pul4 = new PowerUpLife(1080);
        Game.main.LateAddChild(pul4);
        PowerUpLife pul5 = new PowerUpLife(1295);
        Game.main.LateAddChild(pul5);*/
    }
}