using UnityEngine;
using System.Collections;

// This doesn't handle controls anymore, so this name doesn't really apply anymore.
public class RightGunControls : MonoBehaviour {

	public int gunSpeed;
	public GameObject bullet;
	public GameObject timeBullet;

	private float currentTeleportCooldown;
	private float currentTimeCooldown;

	private bool moving;
	private Quaternion lastRot;
	public GameObject flamePrefab;
	GameObject flame;
	public Transform topFlamePos;
	public Transform bottomFlamePos;

	// Use this for initialization
	void Start () {
		moving = false;
		lastRot = transform.rotation;

		currentTeleportCooldown = 10f;
		currentTimeCooldown = 10f;
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTeleportCooldown += Time.deltaTime;
		currentTimeCooldown += Time.deltaTime;
		if(transform.rotation == lastRot)
		{
			moving = false;
			Destroy(flame);
		}
		lastRot = transform.rotation;
	}

	public void moveGun(float speed)
	{
		if(!moving)
		{
			if(speed > 0)
			{
				Quaternion spawnAngle = Quaternion.LookRotation(bottomFlamePos.forward, -bottomFlamePos.up);
				flame = Instantiate(flamePrefab, bottomFlamePos.position, spawnAngle) as GameObject;
				flame.transform.parent = bottomFlamePos;
			}
			else if(speed < 0)
			{
				Quaternion spawnAngle = Quaternion.LookRotation(topFlamePos.forward, topFlamePos.up);
				flame = Instantiate(flamePrefab, topFlamePos.position, spawnAngle) as GameObject;
				flame.transform.parent = topFlamePos;
			}
		}
		moving = true;
		if ((speed > 0 && this.transform.position.y < 21.5) || (speed < 0 && this.transform.position.y > -21.5))
				this.transform.RotateAround (Vector3.zero, Vector3.forward, speed * gunSpeed * Time.deltaTime);
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
			currentTeleportCooldown = 0.0f;
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
			currentTimeCooldown = 0.0f;
		}
	}

	public float GetTeleportTimer()
	{
		return currentTeleportCooldown;
	}
	public float GetDilationTimer()
	{
		return currentTimeCooldown;
	}

}
