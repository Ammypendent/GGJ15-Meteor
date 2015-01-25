using UnityEngine;
using System.Collections;

public class DecorativeAsteroid : CustomGravity
{
	// Used to handle despawning these asteroids
	GameObject mainCamera;

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		Destroy(collider);
		transform.position = new Vector3(0, 0, 500);
		rigidbody.velocity = new Vector3(rigidbody.velocity.x * 2.5f, Mathf.Sign(rigidbody.velocity.y) * 8f, -0.05f);
		mainCamera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(transform.position.z < mainCamera.transform.position.z - 0.5)
		{
			Destroy(gameObject);
		}
	}
}
