using UnityEngine;
using System.Collections;

public class DecorativeAsteroid : CustomGravity
{

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		Destroy(collider);
		transform.position = new Vector3(0, 0, 5);
		rigidbody.velocity = new Vector3(rigidbody.velocity.x * 2.5f, Mathf.Sign(rigidbody.velocity.y) * 0.08f, -0.05f);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
