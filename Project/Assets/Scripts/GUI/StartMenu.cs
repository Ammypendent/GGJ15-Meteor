using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {


	public enum menuIs
	{
		Start,
		Control,
		HUD,
		Finished
	}
	private menuIs ourMenu;

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
	string[] startMenuButtons= new string[3] {"Begin Annihilation", "How To Play", "Quit"};
	int selected = 0;

	
	// Update is called once per frame
	void Update () 
	{
		
		if (ourMenu == menuIs.Start || ourMenu == menuIs.Control)
		{
			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				selected = menuSelection(buttons, selected, "up");
			}
			
			if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				selected = menuSelection(buttons, selected, "down");
			}
		}
		else if (ourMenu == menuIs.Finished)
		{
			if (Input.GetKeyDown(KeyCode.Return))// || Input.GetKeyDown(KeyCode.Space))
			{
				ourMenu = menuIs.Start;
				Global.GameFinished = false;
			}
		}
		else if (ourMenu == menuIs.HUD)
		{

		}

		if (Global.GameFinished) 
		{
			ourMenu = menuIs.Finished;
		}

	}
	
	void OnGUI()
	{

		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height),title);// Produces the Title
		GUI.contentColor = Color.green; // Changes the font to green
		FirstMenu();
		ControlMenu();
		FinishedMenu();

		GUI.SetNextControlName(buttons[0]);
		
		GUI.FocusControl(buttons[selected]);
		
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
		void Start(){
			
			selected = 0;
			
		}
		int menuSelection (string[] buttonsArray, int selectedItem, string direction) {
			
			if (direction == "up") {
				
				if (selectedItem == 0) {
					
					selectedItem = buttonsArray.Length - 1;
					
				} else {
					
					selectedItem -= 1;
					
				}
				
			}
			
			if (direction == "down") {
				
				if (selectedItem == buttonsArray.Length - 1) {
					
					selectedItem = 0;
					
				} else {
					
					selectedItem += 1;
					
				}
				
			}
			
			return selectedItem;
			
		}
	
	void FirstMenu()
	{
		if (_isFirstMenu) // Main Menu
		{

			if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 125, 150, 50), buttons[0]))
			{
				_isFirstMenu = false;
				Global.StartGame ();
			}
			GUI.SetNextControlName(buttons[1]);
			
			if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 75, 150, 50), buttons[1]))
			{			
				ourMenu = menuIs.Control;
			}
			GUI.SetNextControlName(buttons[2]);
			
			if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 25, 150, 50), buttons[2]))
			{
				Application.Quit();
			}


		/*if (GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 - 125, 150, 50), "Begin Annihilation")) 
			{
					_isFirstMenu = false;
					Global.StartGame ();
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 - 75, 150, 50), "How To Play")) 
			{
					_isFirstMenu = false;
					_isControlMenu = true;
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 - 25, 150, 50), "Quit")) 
			{
					Application.Quit();
			}*/

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
				ourMenu = menuIs.Start;
			}
		}
	}
}
