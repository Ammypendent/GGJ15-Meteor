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


	public Texture title;
	public Texture Controls;
	public Texture Controls1;
	public Texture VictoryPlayerOne;
	public Texture VictoryPlayerTwo;
	public Texture CreditsPg1;
	public Texture CreditsPg2;

	private bool controlMenuKeyboard;
	string[] startMenuButtons= new string[3] {"Begin", "How To Play", "Quit"};
	int selected = 0;

	private int finishedPage;

	// Update is called once per frame
	void Update () 
	{
		
		if (ourMenu == menuIs.Start) 
		{
			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				selected = menuSelection(startMenuButtons, selected, "up");
			}
			
			if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				selected = menuSelection(startMenuButtons, selected, "down");
			}
		}
		else if (ourMenu == menuIs.Control)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				controlMenuKeyboard = !controlMenuKeyboard;
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

		//Ready to start game.
		else if (ourMenu == menuIs.HUD && !Global.GameRunning)
		{
			Global.GameRunning = true;
		}

		//If game is just finished
		if (Global.GameFinished && Global.GameRunning) 
		{
			ourMenu = menuIs.Finished;
			finishedPage = 0;
			Global.GameRunning = false;	//Stop the game!
		}


	}
	
	void OnGUI()
	{

		GUI.contentColor = Color.green; // Changes the font to green

		if (ourMenu == menuIs.Start)
		{
			FirstMenu();
		}
		else if (ourMenu == menuIs.Control)
		{
			ControlMenu();
		}
		else if (ourMenu == menuIs.Finished)
		{
			FinishedMenu();
		}


		GUI.SetNextControlName(startMenuButtons[0]);
		
		GUI.FocusControl(startMenuButtons[selected]);

		
	}

	void Start()
	{
		selected = 0;
		finishedPage = 0;
		controlMenuKeyboard = true;
		ourMenu = menuIs.Start;
	}


	int menuSelection (string[] buttonsArray, int selectedItem, string direction) 
	{	
		if (direction == "up") 
		{	
			if (selectedItem == 0) 
			{	
				selectedItem = buttonsArray.Length - 1;	
			} 
			else 
			{
				selectedItem -= 1;
			}
		}
		
		if (direction == "down") 
		{	
			if (selectedItem == buttonsArray.Length - 1) 
			{	
				selectedItem = 0;	
			} 
			else 
			{	
				selectedItem += 1;	
			}
		}
		return selectedItem;
	}


	void FirstMenu()
	{

		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height),title);// Produces the Title

		GUI.SetNextControlName(startMenuButtons[0]);
		if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 125, 150, 50), startMenuButtons[0]))
		{
			ourMenu = menuIs.HUD;
			Global.StartGame ();
		}
		GUI.SetNextControlName(startMenuButtons[1]);
		
		if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 75, 150, 50), startMenuButtons[1]))
		{			
			ourMenu = menuIs.Control;
		}
		GUI.SetNextControlName(startMenuButtons[2]);
		
		if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 25, 150, 50), startMenuButtons[2]))
		{
			Application.Quit();
		}
		GUI.SetNextControlName(startMenuButtons[0]);


		//final menu test sequence - remove soon
		//if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 150, 50), "final test"))
		//{			
		//	ourMenu = menuIs.Finished;
		//}

	}
	
	void ControlMenu()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ourMenu = menuIs.Start;
		}

		GUI.contentColor = Color.white;
		if (controlMenuKeyboard)
		{
			GUI.DrawTexture(new Rect(0, 0, (Screen.width), (Screen.height)),Controls);
		}
		else
		{
			GUI.DrawTexture(new Rect(0, 0, (Screen.width), (Screen.height)),Controls1);
		}

		if (GUI.Button (new Rect (Screen.width / 2 - 70, 55, 150, 50), "Main Menu")) 
		{
			ourMenu = menuIs.Start;
		}
	}

	void FinishedMenu()
	{
		//if (Global.GameFinished) 
		//{
			if (finishedPage == 0)
			{
				//Who is the victor? Display the page of the winner
				if (Global.playerOneHealth > 0)
				{
					GUI.DrawTexture(new Rect(0, 0, (Screen.width), (Screen.height)),VictoryPlayerOne);
				}
				else
				{
					GUI.DrawTexture(new Rect(0, 0, (Screen.width), (Screen.height)),VictoryPlayerTwo);
				}

				//Input to skip to next page
				if (GUI.Button(new Rect(Screen.width / 2 - 70, 110, 150, 50), "continue"))
				{
					finishedPage++;
				}
			}
			else if (finishedPage == 1)
			{
				GUI.DrawTexture(new Rect(0, 0, (Screen.width), (Screen.height)),CreditsPg1);

				//Input to skip to next page
				if (GUI.Button(new Rect(Screen.width / 2 - 70, 110, 150, 50), "continue"))
				{
					finishedPage++;
				}
			}
			else if (finishedPage == 2)
			{
				GUI.DrawTexture(new Rect(0, 0, (Screen.width), (Screen.height)),CreditsPg2);

				//Input to skip to next page
				if (GUI.Button(new Rect(Screen.width / 2 - 70, 110, 150, 50), "continue"))
				{
					finishedPage++;
				}
			}
			else //scrolled through all pages
			{
				ourMenu = menuIs.Start;
			}

		//}
	}
}
