using UnityEngine;
using System.Collections;

public class AndyRotate : MonoBehaviour {

	public int gunSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("up") && this.transform.position.y < 0.225)
			this.transform.RotateAround (Vector3.zero, Vector3.forward, gunSpeed * Time.deltaTime);

		if (Input.GetKey("down") && this.transform.position.y > -0.215)
			this.transform.RotateAround (Vector3.zero, Vector3.back, gunSpeed * Time.deltaTime);
	}
}
