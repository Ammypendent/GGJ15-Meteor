using UnityEngine;
using System.Collections;

// This doesn't handle controls anymore, so this name doesn't really apply anymore.
public class RightGunControls : MonoBehaviour {

	public int gunSpeed;
	public GameObject bullet;
	public GameObject timeBullet;

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

	public void fireTeleport()
	{
		Vector3 spawnPoint = this.transform.position.normalized;
		spawnPoint.x *= 0.425f;
		spawnPoint.y *= 0.425f;
		spawnPoint.z *= 0.425f;
		Instantiate (bullet, spawnPoint, Quaternion.identity);
	}

	public void fireTime()
	{
		Vector3 spawnPoint = this.transform.position.normalized;
		spawnPoint.x *= 0.425f;
		spawnPoint.y *= 0.425f;
		spawnPoint.z *= 0.425f;
		Instantiate (timeBullet, spawnPoint, Quaternion.identity);
	}

}
