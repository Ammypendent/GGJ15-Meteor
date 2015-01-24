using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	private bool _isFirstMenu = true;
	private bool _isLevelSelectMenu = false;
	private bool _isLoadGameMenu = false;
	private bool _isOptionsMenu = false;
	public Texture title;
	public Texture Controls;
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void OnGUI()
	{
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(Screen.width / 2 - 230, Screen.height / 2 - 180 , title.width, title.height),title);
		
		FirstMenu();
		LoadGameMenu();
		LevelSelectMenu();
		OptionsMenu();
		
		if(_isLevelSelectMenu == true || _isLoadGameMenu == true || _isOptionsMenu == true)
		{
			if(GUI.Button(new Rect(10, Screen.height - 35, 150, 25), "Back"))
			{
				_isLevelSelectMenu = false;
				_isLoadGameMenu = false;
				_isOptionsMenu = false;
				_isFirstMenu = true;
			}
		}
	}
	
	void FirstMenu()
	{
		if(_isFirstMenu)
		{
			if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 100, 150, 25), "Begin Annihilation"))
			{
				Application.LoadLevel("Level01");
			}
			
			if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 65, 150, 25), "War Options"))
			{
				_isFirstMenu = false;
				_isOptionsMenu = true;
			}
			
			if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 30, 150, 25), "Go AWOL"))
			{
				Application.Quit();
			}
			
			/*if (GUI.Button(new Rect(10, Screen.height / 2 + 5, 150, 25), "Quit Game"))
			{
				_isFirstMenu = false;
				_isOptionsMenu = true;
			}
			
			if (GUI.Button(new Rect(10, Screen.height / 2 + 40, 150, 25), "Quit Game"))
			{
				Application.Quit();
			}*/
		}
	}
	
	void LoadGameMenu()
	{
		if(_isLoadGameMenu)
		{
			
		}
	}
	
	void LevelSelectMenu()
	{
		if(_isLevelSelectMenu)
		{
			
		}
	}
	
	void OptionsMenu()
	{
		if(_isOptionsMenu)
		{
			if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 100, 150, 25), "Control Schemes"))
			{
				GUI.Label(new Rect(Screen.width / 2 - 230, Screen.height / 2 - 180 , Controls.width / 2, Controls.height / 2),Controls);
			}
			if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 50, 150, 25), "Engineers"))
			{

			}
		}
	}

}
