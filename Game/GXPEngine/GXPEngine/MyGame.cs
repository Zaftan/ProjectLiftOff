using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
    int currentScene = 1;
    //Idk what static does but it told me to put it in for something to work.
    static public Player player;
    static public WaveBuilder builder;
    static public TopWaveBuilder topBuilder;
    public GunDude gd;
    static Sound _music;
    Sound _music2 = new Sound(Settings.ASSET_PATH + "SFX/desertAmbience.mp3", looping: true);
    SoundChannel _musicChannel, _musicChannel2;
    Border border;
    Smoke smoke;
    Lights lights;
    HUD hud;
    Background background;
    StartScreen startScreen;
    GameOver gameOver;
    GameManager gm;


    List<GameObject> gameObjs = new List<GameObject>();

    public bool gameStarted = false;

    private Crosshair cs;// = new Crosshair();

    public MyGame() : base(1920, 1080, false)
    {
        gd = new GunDude();
        gm = new GameManager();
        border = new Border();
        background = new Background();
        smoke = new Smoke();
        lights = new Lights();
        cs = new Crosshair();
        hud = new HUD();
        player = new Player();
        builder = new WaveBuilder();
        topBuilder = new TopWaveBuilder();
        startScreen = new StartScreen();
        gameOver = new GameOver();


        gameObjs.Add(border);
        gameObjs.Add(background);
        gameObjs.Add(smoke);
        gameObjs.Add(lights);
        gameObjs.Add(cs);
        gameObjs.Add(hud);      
        gameObjs.Add(player);
        gameObjs.Add(gd);

        builder.WaveSpawner();
        topBuilder.WaveSpawner();
    }

    void Update()
    {
        cheats();

        if (gameStarted == false)
        {
            currentScene = 1;
        }

        if (Input.GetKey(Key.C))
        {
            currentScene = 2;
            gameStarted = true;
        }

        if (player.playerHealth <= 0)
        {
            currentScene = 3;
            gameStarted = false;
        }
        SceneSwitcher(currentScene);

        builder.CountDown();
        SetChildIndex(smoke, GetChildren().Count - 6);
        SetChildIndex(lights, GetChildren().Count - 5);
        SetChildIndex(cs, GetChildren().Count - 4);
        SetChildIndex(startScreen, GetChildren().Count - 2);
        SetChildIndex(border, GetChildren().Count - 1);
        SetChildIndex(hud, GetChildren().Count - 0);
        topBuilder.Update();
        topBuilder.CountDown();
    }

    void SceneSwitcher(int scene)
    {

        switch (scene)
        {
            case 1:
                
                if (!Game.main.HasChild(startScreen))
                {
                    AddChild(startScreen);               
                    _music = new Sound(Settings.ASSET_PATH + "SFX/introScreenTrack.mp3", looping: true);
                    PlayMusic();
                }
                hud.LateRemove();
            break;

            case 2:
                startScreen.LateRemove();
                GameManager.gameRunning = true;

                foreach (GameObject go in gameObjs)
                {
                    if(!Game.main.HasChild(go))
                    {
                        stopMusic();
                        _music = new Sound(Settings.ASSET_PATH + "SFX/littleTownRobbers_LOOPABLE.mp3", looping: true);
                        _musicChannel2 = _music2.Play(volume: 0.2f);
                        PlayMusic();
                        AddChild(go);                     
                    }
                }

            break;
            case 3:
                GameManager.gameRunning = false;
                if (!Game.main.HasChild(gameOver))
                {
                    AddChild(gameOver);                  
                    SetChildIndex(gameOver, GetChildren().Count - 2);
                }
                foreach (GameObject go in gameObjs)
                {
                    RemoveChild(go);
                }
                currentScene = 4;
            break;
        }
    }

    private static void cheats()
    {
        if (Input.GetKeyDown(Key.M))
        {
            builder.WaveSpawner();
        }

        if (Input.GetKeyDown(Key.K))
        {
            player.playerHealth = -1000;
        }
    }

    void PlayMusic()
    {
        if (_music != null)
        {
            _musicChannel = _music.Play(false, 0, 0.4f);
        }
    }

    public void stopMusic()
    {
        _musicChannel.Stop();
    }

    static void Main()
    {
        new MyGame().Start();
    }
}
