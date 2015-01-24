using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour {


	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newangle = new Vector3 (gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y,gameObject.transform.eulerAngles.z+5.5f*Time.deltaTime);
		gameObject.transform.eulerAngles = newangle;
	}
}
