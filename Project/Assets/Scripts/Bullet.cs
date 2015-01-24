using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int maximumDistance;

	// Use this for initialization
	void Start () {
		// This doesn't work because I don't know.
		//if (this.transform.position != Vector3.zero)
			//Object.Destroy (this, 0.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position != Vector3.zero) 
		{
			this.transform.position = new Vector3 (this.transform.position.normalized.x * 0.01f + this.transform.position.x, 
			                              		   this.transform.position.normalized.y * 0.01f + this.transform.position.y, 
			                                       this.transform.position.normalized.z * 0.01f + this.transform.position.z);

		}
	}
}
