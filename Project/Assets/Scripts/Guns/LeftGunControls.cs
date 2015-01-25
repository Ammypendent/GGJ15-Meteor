using UnityEngine;
using System.Collections;

public class LeftGunControls : MonoBehaviour {

	public int gunSpeed;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void moveGun(float speed)
	{
		if ((speed > 0 && this.transform.position.y < 0.215) || (speed < 0 && this.transform.position.y > -0.215))
			this.transform.RotateAround (Vector3.zero, Vector3.back, speed * gunSpeed * Time.deltaTime);
	}
	
	public void fireGun()
	{
		Instantiate (bullet, this.transform.position, Quaternion.identity);
	}
}
