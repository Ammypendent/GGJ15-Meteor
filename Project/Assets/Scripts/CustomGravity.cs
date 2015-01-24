using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CustomGravity : MonoBehaviour
{

	public Transform tGravityCenter;
	Vector3 v3GravityCenter;

	// Use this for initialization
	protected virtual void Start()
	{
		if(tGravityCenter != null)
		{
			v3GravityCenter = tGravityCenter.position;
		}
		else
		{
			v3GravityCenter = new Vector3(0, 0, 0);
		}
		rigidbody.useGravity = false;

		// Randomize attributes
		rigidbody.velocity = new Vector3(Random.Range(-0.03f, 0.03f), Random.Range(-0.03f, 0.03f), 0);
		rigidbody.angularVelocity = new Vector3(Random.Range(-3.3f, 3.3f), Random.Range(-3.3f, 3.3f), Random.Range(-3.3f, 3.3f));
		transform.localScale = transform.localScale * Random.Range (0.95f, 1.05f);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void FixedUpdate()
	{
		rigidbody.AddForce((v3GravityCenter - transform.position).normalized * Physics.gravity.magnitude, ForceMode.Acceleration);
	}

	void UpdateVelocity()
	{
		rigidbody.velocity *= -1;
	}

	void Teleport(Vector3 destination)
	{
		transform.position = destination;
	}
}
