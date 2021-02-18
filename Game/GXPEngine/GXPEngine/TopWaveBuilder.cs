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
            case 11: wave11(); break;
            case 12: wave12(); break;
            case 13: wave13(); break;
            case 14: wave14(); break;
            case 15: wave15(); break;
            case 16: wave16(); break;
            case 17: wave17(); break;
        }
        waves = rnd.Next(1, 17);
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
        RoadBlock RB2 = new RoadBlock(387);
        Warning WR2 = new Warning(410);
        RoadBlock RB = new RoadBlock(1247);
        Warning WR = new Warning(1280);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);
    }

    private void wave7()
    {
        RoadBlock RB2 = new RoadBlock(603);
        Warning WR2 = new Warning(630);
        RoadBlock RB = new RoadBlock(1037);
        Warning WR = new Warning(1060);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);
    }

    private void wave8()
    {
        RoadBlock RB2 = new RoadBlock(387);
        Warning WR2 = new Warning(410);
        RoadBlock RB = new RoadBlock(821);
        Warning WR = new Warning(850);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);

        PowerUpLife pul = new PowerUpLife(603);
        Game.main.LateAddChild(pul);
        PowerUpSign PS = new PowerUpSign(630);
        Game.main.LateAddChild(PS);
    }

    private void wave9()
    {
        RoadBlock RB2 = new RoadBlock(821);
        Warning WR2 = new Warning(850);
        RoadBlock RB = new RoadBlock(1247);
        Warning WR = new Warning(1280);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);

        PowerUpGun pug = new PowerUpGun(1037);
        Game.main.LateAddChild(pug);
        PowerUpSign PS = new PowerUpSign(1060);
        Game.main.LateAddChild(PS);
    }

    private void wave10()
    {
        RoadBlock RB2 = new RoadBlock(603);
        Warning WR2 = new Warning(630);
        RoadBlock RB = new RoadBlock(821);
        Warning WR = new Warning(850);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);
    }

    private void wave11()
    {
        RoadBlock RB2 = new RoadBlock(821);
        Warning WR2 = new Warning(850);
        RoadBlock RB = new RoadBlock(1037);
        Warning WR = new Warning(1060);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);
    }

    private void wave12()
    {
        RoadBlock RB2 = new RoadBlock(387);
        Warning WR2 = new Warning(410);
        RoadBlock RB = new RoadBlock(603);
        Warning WR = new Warning(630);
        RoadBlock RB3 = new RoadBlock(821);
        Warning WR3 = new Warning(850);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);
        Game.main.LateAddChild(RB3);
        Game.main.LateAddChild(WR3);
    }

    private void wave13()
    {
        RoadBlock RB2 = new RoadBlock(821);
        Warning WR2 = new Warning(850);
        RoadBlock RB = new RoadBlock(1037);
        Warning WR = new Warning(1060);
        RoadBlock RB3 = new RoadBlock(1247);
        Warning WR3 = new Warning(1280);
        Game.main.LateAddChild(RB);
        Game.main.LateAddChild(RB2);
        Game.main.LateAddChild(WR);
        Game.main.LateAddChild(WR2);
        Game.main.LateAddChild(RB3);
        Game.main.LateAddChild(WR3);
    }

    private void wave14()
    {
        PowerUpLife pul = new PowerUpLife(821);
        Game.main.LateAddChild(pul);
        PowerUpSign PS = new PowerUpSign(850);
        Game.main.LateAddChild(PS);
    }

    private void wave15()
    {
        PowerUpGun pug = new PowerUpGun(387);
        Game.main.LateAddChild(pug);
        PowerUpSign PS = new PowerUpSign(410);
        Game.main.LateAddChild(PS);
    }

    private void wave16()
    {
        PowerUpShield pus = new PowerUpShield(1247);
        Game.main.LateAddChild(pus);
        PowerUpSign PS = new PowerUpSign(1280);
        Game.main.LateAddChild(PS);
    }

    private void wave17()
    {
        PowerUpLife pul = new PowerUpLife(603);
        Game.main.LateAddChild(pul);
        PowerUpSign PS = new PowerUpSign(630);
        Game.main.LateAddChild(PS);

        PowerUpShield pus = new PowerUpShield(1037);
        Game.main.LateAddChild(pus);
        PowerUpSign PS2 = new PowerUpSign(1060);
        Game.main.LateAddChild(PS2);
    }
}