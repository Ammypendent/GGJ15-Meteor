using UnityEngine;
using System.Collections;

// This doesn't handle controls anymore, so the name doesn't really apply anymore.
public class LeftGunControls : MonoBehaviour {

	public int gunSpeed;
	public GameObject bullet;
	public GameObject timeBullet;

	private float currentTeleportCooldown;
	private float currentTimeCooldown;

	float currentspeed;
	public float slowDownRate = 3;

	// Use this for initialization
	void Start () {

		currentTeleportCooldown = 10f;
		currentTimeCooldown = 10f;
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTeleportCooldown += Time.deltaTime;
		currentTimeCooldown += Time.deltaTime;

		if (currentspeed > 0)
		{
			currentspeed -= slowDownRate*Time.deltaTime;
			if (currentspeed <0)
			{
				currentspeed = 0;
			}
		}
		else if (currentspeed < 0)
		{
			currentspeed += slowDownRate*Time.deltaTime;
			if (currentspeed > 0)
			{
				currentspeed = 0;
			}
		}
		if ((currentspeed> 0 && this.transform.position.y < 21.5) || (currentspeed < 0 && this.transform.position.y > -21.5))
		{
			this.transform.RotateAround (Vector3.zero, Vector3.back, currentspeed * gunSpeed * Time.deltaTime);
		}

	}

	public void moveGun(float speed)
	{
		if (speed != 0)
		{
			currentspeed = speed;
		}


	}
	
	public void fireTeleport()
	{
		if (currentTeleportCooldown >= Global.teleportCooldown) 
		{
			currentTeleportCooldown = 0;
			Vector3 spawnPoint = this.transform.position.normalized;
			spawnPoint.x *= 42.5f;
			spawnPoint.y *= 42.5f;
			spawnPoint.z *= 42.5f;
			Instantiate (bullet, spawnPoint, Quaternion.identity);
		}
	}

	public void fireTime()
	{
		if (currentTimeCooldown >= Global.timeCooldown) 
		{
			currentTimeCooldown = 0;
			Vector3 spawnPoint = this.transform.position.normalized;
			spawnPoint.x *= 42.5f;
			spawnPoint.y *= 42.5f;
			spawnPoint.z *= 42.5f;
			Instantiate (timeBullet, spawnPoint, Quaternion.identity);
		}
	}
}
