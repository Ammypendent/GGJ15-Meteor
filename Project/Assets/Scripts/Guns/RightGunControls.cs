using UnityEngine;
using System.Collections;

// XBox Gamepad library.
using XInputDotNetPure;

public class RightGunControls : MonoBehaviour {

	public int gunSpeed;
	public GameObject bullet;

	private bool playerIndexSet = false;
	private PlayerIndex playerIndex;
	private GamePadState state;
	private GamePadState prevState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!playerIndexSet || !prevState.IsConnected)
		{
			for (int i = 0; i < 4; ++i)
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					//Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}

		prevState = state;
		state = GamePad.GetState(playerIndex);

		// Detect if a button was pressed this frame
		if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
		{
			fireGun ();
		}



		if (state.ThumbSticks.Left.Y > 0.1 || state.ThumbSticks.Left.Y < -0.1)
			moveGun (state.ThumbSticks.Left.Y);



		if (Input.GetKey("up") && this.transform.position.y < 0.215)
			this.transform.RotateAround (Vector3.zero, Vector3.forward, gunSpeed * Time.deltaTime);
		
		if (Input.GetKey("down") && this.transform.position.y > -0.215)
			this.transform.RotateAround (Vector3.zero, Vector3.back, gunSpeed * Time.deltaTime);

		if (Input.GetKeyDown ("return")) 
		{
			fireGun ();
		}
	}

	void moveGun(float speed)
	{
		if ((speed > 0 && this.transform.position.y < 0.215) || (speed < 0 && this.transform.position.y > -0.215))
				this.transform.RotateAround (Vector3.zero, Vector3.forward, speed * gunSpeed * Time.deltaTime);
	}

	void fireGun()
	{
		Instantiate (bullet, this.transform.position, Quaternion.identity);
	}

}
