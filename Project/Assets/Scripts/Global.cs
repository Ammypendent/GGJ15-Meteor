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

	public static void EndGame()
	{
		Debug.Log("The Game has ended! \n");
		if (playerOneHealth > 0)
		{
			Debug.Log("Player One Survived the onslaught");
		}
		else
		{
			Debug.Log("Player Two Survived the onslaught");
		}
		GameRunning = false;
	}
	
}
