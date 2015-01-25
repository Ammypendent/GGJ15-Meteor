using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	private bool _isFirstMenu = true;
	private bool _isFinishedMenu = false;
	private bool _isControlMenu = false;
	public Texture title;
	public Texture Controls;
	public Texture Controls1;
	public static bool GameRunning;
	public static bool GameFinished;
	public static int playerOneHealth = 20;
	public static int playerTwoHealth= 20;

	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GameFinished) {
		// Hud Menu changes to Finished Game
			
			_isFinishedMenu = true;		}

	}
	
	void OnGUI()
	{

		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height),title);// Produces the Title
		GUI.contentColor = Color.green; // Changes the font to green
		FirstMenu();
		ControlMenu();
		FinishedMenu();


		
		if(_isControlMenu == true)
		{
			if(GUI.Button(new Rect(Screen.width/ 2 - 70, Screen.height/ 2 -10, 150, 25), "Back"))
			{
				_isFinishedMenu = false;
				_isControlMenu = false;
				_isFirstMenu = true;
			}
		}
	}
	
	void FirstMenu()
	{
		if (_isFirstMenu) // Main Menu
		{
		if (GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 - 100, 150, 25), "Begin Annihilation")) 
			{
					_isFirstMenu = false;
					Global.StartGame ();
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 - 65, 150, 25), "How To Play")) 
			{
					_isFirstMenu = false;
					_isControlMenu = true;
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 - 30, 150, 25), "Quit")) 
			{
					Application.Quit();
			}

			//this is just for testing take out soon
			/*if (GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 - 10, 150, 25), "Finals")) 
			{
					_isFirstMenu = false;
					_isFinishedMenu = true;
					
			}*/
		}
	}
	
	void ControlMenu()
	{
		if(_isControlMenu)
		{
				_isFirstMenu = false;
				GUI.contentColor = Color.white;
			GUI.DrawTexture(new Rect(0, 0, (Screen.width), (Screen.height)),Controls);
			//GUI.Label(new Rect(0, 0, (Screen.width), (Screen.height)),Controls1);

			
		}
	}

	void FinishedMenu()
	{
		if (_isFinishedMenu == true) 
		{
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height - 60, 150, 25), "Continue")) 
			{
				_isFirstMenu = true;
				_isFinishedMenu = false;
			}
		}
	}
}
