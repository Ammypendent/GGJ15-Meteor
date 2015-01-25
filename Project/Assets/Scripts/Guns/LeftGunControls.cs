using UnityEngine;
using System.Collections;

// This doesn't handle controls anymore, so the name doesn't really apply anymore.
public class LeftGunControls : MonoBehaviour {

	public int gunSpeed;
	public GameObject bullet;
	public GameObject timeBullet;

	private float currentTeleportCooldown;
	private float currentTimeCooldown;

	// Use this for initialization
	void Start () {

		currentTeleportCooldown = 10f;
		currentTimeCooldown = 10f;
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTeleportCooldown += Time.deltaTime;
		currentTimeCooldown += Time.deltaTime;
	}

	public void moveGun(float speed)
	{
		if ((speed > 0 && this.transform.position.y < 0.215) || (speed < 0 && this.transform.position.y > -0.215))
			this.transform.RotateAround (Vector3.zero, Vector3.back, speed * gunSpeed * Time.deltaTime);
	}
	
	public void fireTeleport()
	{
		if (currentTeleportCooldown >= Global.teleportCooldown)
		{
			currentTeleportCooldown = 0f;
			Vector3 spawnPoint = this.transform.position.normalized;
			spawnPoint.x *= 0.425f;
			spawnPoint.y *= 0.425f;
			spawnPoint.z *= 0.425f;
			Instantiate (bullet, spawnPoint, Quaternion.identity);
		}
	}

	public void fireTime()
	{
		if (currentTimeCooldown >= Global.timeCooldown) 
		{
			currentTimeCooldown = 0f;
			Vector3 spawnPoint = this.transform.position.normalized;
			spawnPoint.x *= 0.425f;
			spawnPoint.y *= 0.425f;
			spawnPoint.z *= 0.425f;
			Instantiate (timeBullet, spawnPoint, Quaternion.identity);
		}
	}
}
