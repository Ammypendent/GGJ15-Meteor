using UnityEngine;
using System.Collections;

public static class Global {


	public static bool GameRunning;

	public static int playerOneHealth;
	public static int playerTwoHealth;



	public static float gameTime;



	public static void StartGame ()
	{
		playerOneHealth = 20;
		playerTwoHealth = 20;

		gameTime = 0;

		GameRunning = true;
	}
	
	
}
