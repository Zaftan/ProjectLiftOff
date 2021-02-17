using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	//Idk what static does but it told me to put it in for something to work.
	static public Player player;
	static public WaveBuilder builder;


	private Crosshair cs;// = new Crosshair();
	public MyGame() : base(1920, 1080, false)
	{
		Border border = new Border();
		Background background = new Background();
		cs = new Crosshair();
		HUD hud = new HUD();
		player = new Player();
		builder = new WaveBuilder();
		builder.WaveSpawner();
		AddChild(background);
		AddChild(border);
		AddChild(cs);
		AddChild(player);
		AddChild(hud);
		SetChildIndex(cs, GetChildren().Count - 1);
	}
	void Update()
    {
        cheats();
		builder.CountDown();
		SetChildIndex(cs, GetChildren().Count - 1);
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