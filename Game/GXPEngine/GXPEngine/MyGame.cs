using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	
	//Idk what static does but it told me to put it in for something to work.
	static public Player player;
	HUD hud;

	public MyGame() : base(1920, 1080, true)
	{
		//bagckground
		player = new Player();
		hud = new HUD();
		AddChild(player);
		AddChild(hud);
    }
	void Update()
	{
	}

	static void Main()
	{
		new MyGame().Start();
	}
}