using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{

	public Texture2D HUDTexture;
	public Texture2D[] PlayerOneIcon;
	public Texture2D[] PlayerTwoIcon;
	public Texture2D[] Teleport;
	public Texture2D[] TimeDilation;
	public Texture2D Backfill;

	public GameObject leftGun;
	public GameObject rightGun;

	LeftGunControls lGunScript;
	RightGunControls rGunScript;

	int healthStageOne;
	int healthStageTwo;

	Vector2 scaleRatio;

	Color[] UIColor;

	bool[] justHit;
	float[] justHitTimer;
	int[] lastHealth;

	// Use this for initialization
	void Start()
	{
		healthStageOne = 0;
		healthStageTwo = 0;

		UIColor = new Color[2];
		UIColor[0] = new Color(0, 1, 0, 1);
		UIColor[1] = UIColor[0];

		justHit = new bool[2];
		justHit[0] = true;
		justHit[1] = true;

		justHitTimer = new float[2];
		justHitTimer[0] = -5;
		justHitTimer[1] = -5;

		lastHealth = new int[2];
		lastHealth[0] = Global.playerOneHealth;
		lastHealth[1] = Global.playerTwoHealth;

		scaleRatio = new Vector2 ((float)HUDTexture.width / (float)Screen.width, (float)HUDTexture.height / (float)Screen.height);

		lGunScript = leftGun.GetComponent<LeftGunControls>();
		rGunScript = rightGun.GetComponent<RightGunControls>();
	}
	
	// Update is called once per frame
	void Update()
	{
		// Player 1 health colors
		if(lastHealth[0] != Global.playerOneHealth)
		{
			if((float)Global.playerOneHealth / (float)Global.playerOneHealthMax > 0.75)
			{
				UIColor[0] = new Color(0, 1, 0, 1);
			}
			else if((float)Global.playerOneHealth / (float)Global.playerOneHealthMax > 0.5)
			{
				UIColor[0] = new Color(1, 1, 0, 1);
			}
			else if((float)Global.playerOneHealth / (float)Global.playerOneHealthMax > 0.25)
			{
				UIColor[0] = new Color(1, 0.5f, 0, 1);
			}
			else// if((float)Global.playerOneHealth / (float)Global.playerOneHealthMax > 0.5)
			{
				UIColor[0] = new Color(1, 0, 0, 1);
			}
			lastHealth[0] = Global.playerOneHealth;
			if(justHit[0] == false)
			{
				justHit[0] = true;
				justHitTimer[0] = Time.time;
			}
		}

		// Player 2 health colors
		if(lastHealth[1] != Global.playerTwoHealth)
		{
			if((float)Global.playerTwoHealth / (float)Global.playerTwoHealthMax > 0.75)
			{
				UIColor[1] = new Color(0, 1, 0, 1);
			}
			else if((float)Global.playerTwoHealth / (float)Global.playerTwoHealthMax > 0.5)
			{
				UIColor[1] = new Color(1, 1, 0, 1);
			}
			else if((float)Global.playerTwoHealth / (float)Global.playerTwoHealthMax > 0.25)
			{
				UIColor[1] = new Color(1, 0.5f, 0, 1);
			}
			else// if((float)Global.playerTwoHealth / (float)Global.playerTwoHealthMax > 0.5)
			{
				UIColor[1] = new Color(1, 0, 0, 1);
			}
			lastHealth[1] = Global.playerTwoHealth;
			if(justHit[1] == false)
			{
				justHit[1] = true;
				justHitTimer[1] = Time.time;
			}
		}

		if(justHit[0] && Time.time - justHitTimer[0] > 0.6666)
		{
			justHit[0] = false;
		}
		if(justHit[1] && Time.time - justHitTimer[1] > 0.6666)
		{
			justHit[1] = false;
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), HUDTexture);

		if(lGunScript.GetTeleportTimer() < Global.teleportCooldown)
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.2f + Teleport[1].width, Screen.height * 0.98f - Teleport[1].height * (lGunScript.GetTeleportTimer() / Global.teleportCooldown), Teleport[1].width, Teleport[1].height * (lGunScript.GetTeleportTimer() / Global.teleportCooldown)), Backfill);
			GUI.DrawTexture(new Rect(Screen.width * 0.2f + Teleport[1].width, Screen.height * 0.98f - Teleport[1].height, Teleport[1].width, Teleport[1].height), Teleport[1]);
		}
		else
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.2f + Teleport[0].width, Screen.height * 0.98f - Teleport[0].height, Teleport[0].width, Teleport[0].height), Teleport[0]);
		}

		if(rGunScript.GetTeleportTimer() < Global.teleportCooldown)
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.8f - Teleport[1].width, Screen.height * 0.98f - Teleport[1].height * (rGunScript.GetTeleportTimer() / Global.teleportCooldown), Teleport[1].width, Teleport[1].height * (rGunScript.GetTeleportTimer() / Global.teleportCooldown)), Backfill);
			GUI.DrawTexture(new Rect(Screen.width * 0.8f - Teleport[1].width, Screen.height * 0.98f - Teleport[1].height, Teleport[1].width, Teleport[1].height), Teleport[1]);
		}
		else
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.8f - Teleport[0].width, Screen.height * 0.98f - Teleport[0].height, Teleport[0].width, Teleport[0].height), Teleport[0]);
		}

		if(lGunScript.GetDilationTimer() < Global.timeCooldown)
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.2f + TimeDilation[1].width * 2.1f, Screen.height * 0.98f - TimeDilation[1].height * (lGunScript.GetDilationTimer() / Global.timeCooldown), TimeDilation[1].width, TimeDilation[1].height * (lGunScript.GetDilationTimer() / Global.timeCooldown)), Backfill);
			GUI.DrawTexture(new Rect(Screen.width * 0.2f + TimeDilation[1].width * 2.1f, Screen.height * 0.98f - TimeDilation[1].height, TimeDilation[1].width, TimeDilation[1].height), TimeDilation[1]);
		}
		else
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.2f + TimeDilation[0].width * 2.1f, Screen.height * 0.98f - TimeDilation[0].height, TimeDilation[0].width, TimeDilation[0].height), TimeDilation[0]);
		}
		
		if(rGunScript.GetDilationTimer() < Global.timeCooldown)
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.8f - TimeDilation[1].width * 2.1f, Screen.height * 0.98f - TimeDilation[1].height * (rGunScript.GetDilationTimer() / Global.timeCooldown), TimeDilation[1].width, TimeDilation[1].height * (rGunScript.GetDilationTimer() / Global.timeCooldown)), Backfill);
			GUI.DrawTexture(new Rect(Screen.width * 0.8f - TimeDilation[1].width * 2.1f, Screen.height * 0.98f - TimeDilation[1].height, TimeDilation[1].width, TimeDilation[1].height), TimeDilation[1]);
		}
		else
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.8f - TimeDilation[0].width * 2.1f, Screen.height * 0.98f - TimeDilation[0].height, TimeDilation[0].width, TimeDilation[0].height), TimeDilation[0]);
		}

		GUI.color = UIColor[0];
		if(!justHit[0])
		{
			GUI.DrawTexture(new Rect((Screen.width * 0.175f) - (PlayerOneIcon[0].width * scaleRatio.y), (Screen.height * 0.97f) - (PlayerOneIcon[0].height * scaleRatio.y), PlayerOneIcon[0].width * scaleRatio.y, PlayerOneIcon[0].height * scaleRatio.y), PlayerOneIcon[0]);
		}
		else if(justHit[0])
		{
			if(Time.time - justHitTimer[0] < 0.3333)
			{
				GUI.DrawTexture(new Rect((Screen.width * 0.187f) - (PlayerOneIcon[1].width * scaleRatio.y), (Screen.height * 0.97f) - (PlayerOneIcon[1].height * scaleRatio.y), PlayerOneIcon[1].width * scaleRatio.y, PlayerOneIcon[1].height * scaleRatio.y), PlayerOneIcon[1]);
			}
			else
			{
				GUI.DrawTexture(new Rect((Screen.width * 0.175f) - (PlayerOneIcon[2].width * scaleRatio.y), (Screen.height * 0.97f) - (PlayerOneIcon[2].height * scaleRatio.y), PlayerOneIcon[2].width * scaleRatio.y, PlayerOneIcon[2].height * scaleRatio.y), PlayerOneIcon[2]);
			}
		}

		if(!justHit[1])
		{
			GUI.DrawTexture(new Rect((Screen.width * 0.865f) - (PlayerTwoIcon[0].width * scaleRatio.y), (Screen.height * 0.97f) - (PlayerTwoIcon[0].height * scaleRatio.y), PlayerTwoIcon[0].width * scaleRatio.y, PlayerTwoIcon[0].height * scaleRatio.y), PlayerTwoIcon[0]);
		}
		else if(justHit[1])
		{
			if(Time.time - justHitTimer[1] < 0.3333)
			{
				GUI.DrawTexture(new Rect((Screen.width * 0.905f) - (PlayerTwoIcon[1].width * scaleRatio.y * 0.8f), (Screen.height * 0.97f) - (PlayerTwoIcon[1].height * scaleRatio.y * 0.8f), PlayerTwoIcon[1].width * scaleRatio.y * 0.8f, PlayerTwoIcon[1].height * scaleRatio.y * 0.8f), PlayerTwoIcon[1]);
			}
			else
			{
				GUI.DrawTexture(new Rect((Screen.width * 0.865f) - (PlayerTwoIcon[2].width * scaleRatio.y), (Screen.height * 0.97f) - (PlayerTwoIcon[2].height * scaleRatio.y), PlayerTwoIcon[2].width * scaleRatio.y, PlayerTwoIcon[2].height * scaleRatio.y), PlayerTwoIcon[2]);
			}
		}

		//GUI.color = UIColor[1];
		//GUI.DrawTexture(new Rect((Screen.width * 0.865f) - (PlayerTwoIcon[0].width * scaleRatio.y), (Screen.height * 0.97f) - (PlayerTwoIcon[0].height * scaleRatio.y), PlayerTwoIcon[0].width * scaleRatio.y, PlayerTwoIcon[0].height * scaleRatio.y), PlayerTwoIcon[0]);
		//GUI.DrawTexture(new Rect((Screen.width * 0.905f) - (PlayerTwoIcon[1].width * scaleRatio.y), (Screen.height * 0.97f) - (PlayerTwoIcon[1].height * scaleRatio.y), PlayerTwoIcon[1].width * scaleRatio.y, PlayerTwoIcon[1].height * scaleRatio.y), PlayerTwoIcon[1]);
		//GUI.DrawTexture(new Rect((Screen.width * 0.865f) - (PlayerTwoIcon[2].width * scaleRatio.y), (Screen.height * 0.97f) - (PlayerTwoIcon[2].height * scaleRatio.y), PlayerTwoIcon[2].width * scaleRatio.y, PlayerTwoIcon[2].height * scaleRatio.y), PlayerTwoIcon[2]);
		//GUI.DrawTexture(new Rect(Screen.width * 0.8f, Screen.height * 0.6f, Screen.width * 0.1f, Screen.height * 0.2f), PlayerOneIcon[healthStageOne]);
	}

}
