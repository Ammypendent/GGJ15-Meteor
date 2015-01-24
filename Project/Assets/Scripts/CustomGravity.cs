using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CustomGravity : MonoBehaviour
{

	public Transform tGravityCenter;
	Vector3 v3GravityCenter;

	// Use this for initialization
	void Start()
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
