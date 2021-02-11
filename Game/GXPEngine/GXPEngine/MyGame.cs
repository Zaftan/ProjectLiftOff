using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	//Idk what static does but it told me to put it in for something to work.
	static public Player player;
	static public WaveBuilder builder;
	public MyGame() : base(1920, 1080, false)
	{
		Border border = new Border();
		Background background = new Background();
		HUD hud = new HUD();
		player = new Player();
		builder = new WaveBuilder();
		builder.WaveSpawner();
		AddChild(background);
		AddChild(border);
		AddChild(player);
		AddChild(hud);
	}
	void Update()
    {
        cheats();
		builder.CountDown();
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