using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;

/// <summary>
/// public static class GameResources: This class will be used to add the needed resources to the game once running.
/// </summary>
public static class GameResources
{
    /// <summary>
    /// This is a static void method that does not take in any parameters and also does not return anything.
    /// It Loads the required fonts to the game.
    /// </summary>
	private static void LoadFonts()
	{
		NewFont("ArialLarge", "arial.ttf", 80);
		NewFont("Courier", "cour.ttf", 14);
		NewFont("CourierSmall", "cour.ttf", 8);
		NewFont("Menu", "ffaccess.ttf", 8);
	}

    /// <summary>
    /// This is a static void method that does not take in any parameters and also does not return anything.
    /// It Loads the required images to the game.
    /// </summary>
	private static void LoadImages()
	{
		//Backgrounds
		NewImage("Menu", "main_page.jpg");
		NewImage("Discovery", "discover.jpg");
		NewImage("Deploy", "deploy.jpg");

		//Deployment
		NewImage("LeftRightButton", "deploy_dir_button_horiz.png");
		NewImage("UpDownButton", "deploy_dir_button_vert.png");
		NewImage("SelectedShip", "deploy_button_hl.png");
		NewImage("PlayButton", "deploy_play_button.png");
		NewImage("RandomButton", "deploy_randomize_button.png");

		//Ships
		int i = 0;
		for (i = 1; i <= 5; i++) {
			NewImage("ShipLR" + i, "ship_deploy_horiz_" + i + ".png");
			NewImage("ShipUD" + i, "ship_deploy_vert_" + i + ".png");
		}

		//Explosions
		NewImage("Explosion", "explosion.png");
		NewImage("Splash", "splash.png");

	}

    /// <summary>
    /// This is a static void method that does not take in any parameters and also does not return anything.
    /// It Loads the required sounds to the game.
    /// </summary>
	private static void LoadSounds()
	{
		NewSound("Error", "error.wav");
		NewSound("Hit", "hit.wav");
		NewSound("Sink", "sink.wav");
		//NewSound("Siren", "siren.wav");
		NewSound("Miss", "watershot.wav");
		NewSound("Winner", "winner.wav");
		NewSound("Lose", "lose.wav");
	}

    /// <summary>
    /// This is a static void method that does not take in any parameters and also does not return anything.
    /// It Loads the required music to the game.
    /// </summary>
	private static void LoadMusic()
	{
		NewMusic("Background", "horrordrone.mp3");
	}

	/// <summary>
    /// public static Font : Gets a Font Loaded in the Resources.
	/// </summary>
	/// <param name="font">Name of Font</param>
	/// <returns>The Font Loaded with this Name</returns>
	public static Font GameFont(string font)
	{
		return _Fonts[font];
	}

	/// <summary>
    /// public static Bitmap : Gets an Image loaded in the Resources.
	/// </summary>
	/// <param name="image">Name of image</param>
	/// <returns>The image loaded with this name</returns>
	public static Bitmap GameImage(string image)
	{
		return _Images[image];
	}

	/// <summary>
    /// public static SoundEffect: Gets an sound loaded in the Resources.
	/// </summary>
	/// <param name="sound">Name of sound</param>
	/// <returns>The sound with this name</returns>
	public static SoundEffect GameSound(string sound)
	{
		return _Sounds[sound];
	}

	/// <summary>
    /// public static Music: Gets the music loaded in the Resources.
	/// </summary>
	/// <param name="music">Name of music</param>
	/// <returns>The music with this name</returns>
	public static Music GameMusic(string music)
	{
		return _Music[music];
	}

	private static Dictionary<string, Bitmap> _Images = new Dictionary<string, Bitmap>();
	private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font>();
	private static Dictionary<string, SoundEffect> _Sounds = new Dictionary<string, SoundEffect>();
	private static Dictionary<string, Music> _Music = new Dictionary<string, Music>();
	private static Bitmap _Background;
	private static Bitmap _Animation;
	private static Bitmap _LoaderFull;
	private static Bitmap _LoaderEmpty;
	private static Font _LoadingFont;
	private static SoundEffect _StartSound;

    /// <summary>
    /// This is a static void method that does not take in any parameters and also does not return anything.
    /// This void stores all of the Games Media Resources, such as Images, Fonts
    /// Sounds, Music.
    /// </summary>
    public static void LoadResources()
	{
		int width = 0;
		int height = 0;

		width = SwinGame.ScreenWidth();
		height = SwinGame.ScreenHeight();

		SwinGame.ChangeScreenSize(800, 600);

		ShowLoadingScreen();

		ShowMessage("Loading fonts...", 0);
		LoadFonts();
		SwinGame.Delay(100);

		ShowMessage("Loading images...", 1);
		LoadImages();
		SwinGame.Delay(100);

		ShowMessage("Loading sounds...", 2);
		LoadSounds();
		SwinGame.Delay(100);

		ShowMessage("Loading music...", 3);
		LoadMusic();
		SwinGame.Delay(100);

		SwinGame.Delay(100);
		ShowMessage("Game loaded...", 5);
		SwinGame.Delay(100);
		//EndLoadingScreen(width, height);
	}

    /// <summary>
    /// This is a static void method that does not take in any parameters and also does not return anything.
    /// This void Shows the loading screen of the game.
    /// </summary>
	private static void ShowLoadingScreen()
	{
		_Background = SwinGame.LoadBitmap("SplashBack.png");
		SwinGame.DrawBitmap(_Background, 0, 0);
		SwinGame.RefreshScreen();
		SwinGame.ProcessEvents();

		_Animation = SwinGame.LoadBitmap("SwinGameAni.jpg");
		_LoadingFont = SwinGame.LoadFont("arial.ttf", 12);
		_StartSound = Audio.LoadSoundEffect("SwinGameStart.ogg");

		_LoaderFull = SwinGame.LoadBitmap("loader_full.png");
		_LoaderEmpty = SwinGame.LoadBitmap("loader_empty.png");

		PlaySwinGameIntro();
	}

    /// <summary>
    /// This is a static void method that does not take in any parameters and also does not return anything.
    /// This void Plays the swin game intro.
    /// </summary>
    /// <remarks>
    /// Isuru: TODO: remove the old swingame intro 
    /// </remarks>
	private static void PlaySwinGameIntro()
	{
		const int ANI_X = 143;
		const int ANI_Y = 134;
		const int ANI_W = 546;
		const int ANI_H = 327;
		const int ANI_V_CELL_COUNT = 6;
		const int ANI_CELL_COUNT = 11;

		Audio.PlaySoundEffect(_StartSound);
		SwinGame.Delay(200);

		int i = 0;
		for (i = 0; i <= ANI_CELL_COUNT - 1; i++) {
			SwinGame.DrawBitmap(_Background, 0, 0);
			//SwinGame.DrawBitmapPart(_Animation, (i / ANI_V_CELL_COUNT) * ANI_W, (i % ANI_V_CELL_COUNT) * ANI_H, ANI_W, ANI_H, ANI_X, ANI_Y);
			SwinGame.Delay(20);
			SwinGame.RefreshScreen();
			SwinGame.ProcessEvents();
		}

		SwinGame.Delay(1500);

	}

    /// <summary>
    /// This is a static void method that takes in string and an integer as parameters and does not return anything.
    /// This void Shows a message in the game.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="number">Number.</param>
	private static void ShowMessage(string message, int number)
	{
		const int TX = 310;
		const int TY = 493;
		const int TW = 200;
		const int TH = 25;
		const int STEPS = 5;
		const int BG_X = 279;
		const int BG_Y = 453;

		int fullW = 0;

		fullW = 260 * number / STEPS;
		SwinGame.DrawBitmap(_LoaderEmpty, BG_X, BG_Y);

        // TODO: Do this the right way
        SwinGame.DrawCell (_LoaderFull, 0, BG_X, BG_Y);
		//Draw Bitmap Part   (src, srcX, srcY, srcW, srcH, x, y)
		//SwinGame.DrawBitmapPart(_LoaderFull, 0, 0, fullW, 66, BG_X, BG_Y);

		Rectangle toDraw = new Rectangle ();
        toDraw.X = TX;
		toDraw.Y =  TY;
		toDraw.Width = TW;
        toDraw.Height = TH;

        SwinGame.DrawText (message, Color.White, Color.Transparent,_LoadingFont,FontAlignment.AlignCenter,toDraw);
		//SwinGame.DrawTextLines(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, TX, TY, TW, TH);

		SwinGame.RefreshScreen();
		SwinGame.ProcessEvents();
	}

    /// <summary>
    /// This is a static void method that takes in integer's as parameters and does not return anything.
    /// This void Ends the loading screen and displays the next state.
    /// </summary>
    /// <param name="width">Width.</param>
    /// <param name="height">Height.</param>
	private static void EndLoadingScreen(int width, int height)
	{
		SwinGame.ProcessEvents();
		SwinGame.Delay(500);
		SwinGame.ClearScreen();
		SwinGame.RefreshScreen();
		SwinGame.FreeFont(_LoadingFont);
		SwinGame.FreeBitmap(_Background);
		SwinGame.FreeBitmap(_Animation);
		SwinGame.FreeBitmap(_LoaderEmpty);
		SwinGame.FreeBitmap(_LoaderFull);
		Audio.FreeSoundEffect(_StartSound);
		SwinGame.ChangeScreenSize(width, height);
	}

    /// <summary>
    /// This is a static void method that takes in two strings and an integr as parameters and also does not return anything.
    /// This void News fonts to the game screen.
    /// </summary>
    /// <param name="fontName">Font name.</param>
    /// <param name="filename">Filename.</param>
    /// <param name="size">Size.</param>
	private static void NewFont(string fontName, string filename, int size)
	{
		_Fonts.Add(fontName, SwinGame.LoadFont(filename, size));
	}

    /// <summary>
    /// This is a static void method that takes in two strings as parameters and does not return anything.
    /// This void News images to the game screen.
    /// </summary>
    /// <param name="imageName">Image name.</param>
    /// <param name="filename">Filename.</param>
    private static void NewImage(string imageName, string filename)
	{
		_Images.Add(imageName, SwinGame.LoadBitmap(filename));
	}

    /// <summary>
    /// This is a static void method that takes in two strings and a Color from swingame library as parameters and does not return anything.
    /// This void News the transparent color image.
    /// </summary>
    /// <param name="imageName">Image name.</param>
    /// <param name="fileName">File name.</param>
    /// <param name="transColor">Trans color.</param>
    private static void NewTransparentColorImage(string imageName, string fileName, Color transColor)
	{
        Bitmap bitmap = SwinGame.LoadBitmap (SwinGame.PathToResource (fileName,ResourceKind.BitmapResource));
		//Bitmap bitmap = SwinGame.LoadBitmap (SwinGame.PathToResource (fileName, ResourceKind.BitmapResource), true, transColor);
		_Images.Add(imageName, bitmap);
	}
	private static void NewTransparentColourImage(string imageName, string fileName, Color transColor)
	{
		NewTransparentColorImage(imageName, fileName, transColor);
	}

    /// <summary>
    /// This is a static void method that takes in two strings as parameters and does not return anything.
    /// This void News the sound.
    /// </summary>
    /// <param name="soundName">Sound name.</param>
    /// <param name="filename">Filename.</param>
	private static void NewSound(string soundName, string filename)
	{
		_Sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
	}

    /// <summary>
    /// This is a static void method that takes in two strings as parameters and does not return anything.
    /// This void News the music.
    /// </summary>
    /// <param name="musicName">Music name.</param>
    /// <param name="filename">Filename.</param>
	private static void NewMusic(string musicName, string filename)
	{
		_Music.Add(musicName, Audio.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
	}

    /// <summary>
    /// This is a static void method that takes no parameters and does not return anything.
    /// This void Frees the fonts.
    /// </summary>
	private static void FreeFonts()
	{
		foreach (Font obj in _Fonts.Values) {
			SwinGame.FreeFont(obj);
		}
	}

    /// <summary>
    /// This is a static void method that takes no parameters and does not return anything.
    /// This void Frees the images.
    /// </summary>
    private static void FreeImages()
	{
		foreach (Bitmap obj in _Images.Values) {
			SwinGame.FreeBitmap(obj);
		}
	}

    /// <summary>
    /// This is a static void method that takes no parameters and does not return anything.
    /// This void Frees the sounds.
    /// </summary>
    private static void FreeSounds()
	{		
		foreach (SoundEffect obj in _Sounds.Values) {
			Audio.FreeSoundEffect(obj);
		}
	}

    /// <summary>
    /// This is a static void method that takes no parameters and does not return anything.
    /// This void Frees the music.
    /// </summary>
    private static void FreeMusic()
	{

		foreach (Music obj in _Music.Values) {
			Audio.FreeMusic(obj);
		}
	}

    /// <summary>
    /// This is a static void method that takes no parameters and does not return anything.
    /// This void Frees the resources.
    /// </summary>
    public static void FreeResources()
	{
		FreeFonts();
		FreeImages();
		FreeMusic();
		FreeSounds();
		SwinGame.ProcessEvents();
	}
}