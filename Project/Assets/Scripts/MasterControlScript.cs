using UnityEngine;
using System.Collections;

// XBox Gamepad library.
using XInputDotNetPure;

public class MasterControlScript : MonoBehaviour {

	public GameObject rightGunObject;
	public GameObject leftGunObject;

	private RightGunControls rightGun;
	private LeftGunControls leftGun;

	private bool playerOneGamePad;
	private bool playerTwoGamePad;
	private PlayerIndex playerOne;
	private PlayerIndex playerTwo;

	private GamePadState statePlayerOne;
	private GamePadState prevStatePlayerOne;
	private GamePadState statePlayerTwo;
	private GamePadState prevStatePlayerTwo;


	// Use this for initialization
	void Start () 
	{

		// Set up access to scripts for the left and right guns.
		rightGun = rightGunObject.GetComponent<RightGunControls> ();
		leftGun = leftGunObject.GetComponent<LeftGunControls> ();

		// Set up XBox game pads.
		playerOneGamePad = false;
		playerTwoGamePad = false;
		for (int i = 0; i < 4 && playerTwoGamePad == false; ++i)
		{
			PlayerIndex testPlayerIndex = (PlayerIndex)i;
			GamePadState testState = GamePad.GetState(testPlayerIndex);
			if (testState.IsConnected)
			{
				if (playerOneGamePad == false)
				{
					playerOneGamePad = true;
					playerOne = testPlayerIndex;
				}
				else
				{
					playerTwoGamePad = true;
					playerTwo = testPlayerIndex;
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (playerOneGamePad) 
		{
			prevStatePlayerOne = statePlayerOne;
			statePlayerOne = GamePad.GetState (playerOne);

			// Detect if a button was pressed this frame
			if (prevStatePlayerOne.Buttons.A == ButtonState.Released && statePlayerOne.Buttons.A == ButtonState.Pressed) 
			{
				leftGun.fireTeleport ();
			}
			else if (prevStatePlayerOne.Buttons.X == ButtonState.Released && statePlayerOne.Buttons.X == ButtonState.Pressed)
			{
				leftGun.fireTime();
			}
			if (statePlayerOne.ThumbSticks.Left.Y > 0.1 || statePlayerOne.ThumbSticks.Left.Y < -0.1)
					leftGun.moveGun (statePlayerOne.ThumbSticks.Left.Y);
		} 
		else {
			if (Input.GetKey("w") && this.transform.position.y < 0.215)
				leftGun.moveGun(1f);
			
			if (Input.GetKey("s") && this.transform.position.y > -0.215)
				leftGun.moveGun(-1f);
			
			if (Input.GetKeyDown ("a")) 
			{
				leftGun.fireTeleport();
			}
			else if (Input.GetKeyDown ("d"))
			{
				leftGun.fireTime();
			}
		}

		if (playerTwoGamePad) 
		{
			prevStatePlayerTwo = statePlayerTwo;
			statePlayerTwo = GamePad.GetState(playerTwo);

			// Detect if a button was pressed this frame
			if (prevStatePlayerTwo.Buttons.A == ButtonState.Released && statePlayerTwo.Buttons.A == ButtonState.Pressed)
			{
				rightGun.fireTeleport ();
			}
			else if (prevStatePlayerTwo.Buttons.X == ButtonState.Released && statePlayerTwo.Buttons.X == ButtonState.Pressed)
			{
				rightGun.fireTime ();
			}
			
			if (statePlayerTwo.ThumbSticks.Left.Y > 0.1 || statePlayerTwo.ThumbSticks.Left.Y < -0.1)
				rightGun.moveGun (statePlayerTwo.ThumbSticks.Left.Y);

		}
		else 
		{
			if (Input.GetKey("up") && this.transform.position.y < 0.215)
				rightGun.moveGun(1f);
			
			if (Input.GetKey("down") && this.transform.position.y > -0.215)
				rightGun.moveGun(-1f);
			
			if (Input.GetKeyDown ("left")) 
			{
				rightGun.fireTeleport ();
			}
			else if (Input.GetKeyDown ("right"))
			{
				rightGun.fireTime();
			}
		}



	}
}
