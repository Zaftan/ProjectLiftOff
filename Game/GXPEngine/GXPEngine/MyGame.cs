using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	//Idk what static does but it told me to put it in for something to work.
	static public Player player;

	public MyGame() : base(1920, 1080, false)
	{
		Border border = new Border();
		Background background = new Background();
		player = new Player();
		AddChild(background);
		AddChild(border);
		AddChild(player);
		
    }
	void Update()
	{
	}

	static void Main()
	{
		new MyGame().Start();
	}
}