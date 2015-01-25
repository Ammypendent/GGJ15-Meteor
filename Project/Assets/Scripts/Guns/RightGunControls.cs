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
	}

	public void moveGun(float speed)
	{
		if ((speed > 0 && this.transform.position.y < 0.215) || (speed < 0 && this.transform.position.y > -0.215))
				this.transform.RotateAround (Vector3.zero, Vector3.forward, speed * gunSpeed * Time.deltaTime);
	}

	public void fireGun()
	{
		Instantiate (bullet, this.transform.position, Quaternion.identity);
	}

}
