using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	//Idk what static does but it told me to put it in for something to work.
	static public Player player;
	static public WaveBuilder builder;
	static public TopWaveBuilder topBuilder;
	Border border;
	Smoke smoke;
	Lights lights;
	HUD hud;

	private Crosshair cs;// = new Crosshair();
	public MyGame() : base(1920, 1080, false)
	{
		border = new Border();
		Background background = new Background();
		smoke = new Smoke();
		lights = new Lights();
		cs = new Crosshair();
		hud = new HUD();
		player = new Player();
		builder = new WaveBuilder();
		builder.WaveSpawner();
		topBuilder = new TopWaveBuilder();
        topBuilder.WaveSpawner();
		AddChild(hud);
		AddChild(background);
		AddChild(border);
		AddChild(lights);
		AddChild(smoke);
		AddChild(cs);
		AddChild(player);
		

	}
	void Update()
    {
        cheats();
		builder.CountDown();
		SetChildIndex(smoke, GetChildren().Count - 4);
		SetChildIndex(lights, GetChildren().Count - 3);
		SetChildIndex(cs, GetChildren().Count - 2);
		SetChildIndex(border, GetChildren().Count - 1);
		SetChildIndex(hud, GetChildren().Count - 0);
		topBuilder.Update();
		topBuilder.CountDown();
	}

    private static void cheats()
    {
        if (Input.GetKeyDown(Key.M))
        {
            builder.WaveSpawner();
        }
    }

    static void Main()
	{
		new MyGame().Start();
	}
}
