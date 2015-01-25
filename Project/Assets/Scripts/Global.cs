using UnityEngine;
using System.Collections;

public static class Global {


	public static bool GameRunning;
	public static bool GameFinished;

	public static int playerOneHealth;
	public static int playerTwoHealth;

	// The amount of remaining health that triggers playing faster and faster music.
	public static int mediumMusic;
	public static int fastMusic;

	public static float gameTime;

	public static float teleportCooldown;
	public static float timeCooldown;

	public static void StartGame ()
	{
		playerOneHealth = 20;
		playerTwoHealth = 20;
		// Change these if health is updated.  
		// 50% max health for medium, 25% max health for fast.
		mediumMusic = 10;
		fastMusic = 5;

		// Time in seconds between teleport and time shots.
		teleportCooldown = 0.25f;
		timeCooldown = 10f;

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
