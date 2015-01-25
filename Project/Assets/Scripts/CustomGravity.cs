using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CustomGravity : MonoBehaviour
{

	public Transform tGravityCenter;
	Vector3 v3GravityCenter;
	bool gravityOn;
	bool teleporting;

	bool dilating;
	float timeDilationFactor;
	Vector3 timeDilationCenter;
	public float timeDilationShotRadius;
	Vector3 timeDilationEntryVelocity;

	// Use this for initialization
	protected virtual void Start()
	{
		timeDilationShotRadius = 1.0f;
		timeDilationFactor = 1.0f;
		gravityOn = true;
		teleporting = false;
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
		if(dilating)
		{
			timeDilationFactor = Mathf.Min(Mathf.Max((timeDilationCenter - transform.position).magnitude / timeDilationShotRadius, 0.2f), 1);
			print (timeDilationFactor);
		}
	}

	void FixedUpdate()
	{
		if(gravityOn)
		{
			if(!dilating)
			{
				rigidbody.AddForce((v3GravityCenter - transform.position).normalized * Physics.gravity.magnitude, ForceMode.Acceleration);
			}
			else
			{
				rigidbody.velocity = timeDilationEntryVelocity * timeDilationFactor;
			}
		}
	}

	public void Impact(Vector3 destination)
	{
		if(!teleporting)
		{
			StartCoroutine(DelayTeleport(destination));
		}
		//UpdateVelocity();
	}

	void UpdateVelocity(Vector3 oldVelocity)
	{
		//rigidbody.velocity *= -0.5f;
		rigidbody.velocity = new Vector3(oldVelocity.x * -0.5f, (v3GravityCenter.y - transform.position.y) + Random.Range(-0.03f, 0.03f), 0);
	}

	void Teleport(Vector3 destination)
	{
		transform.position = destination;
	}

	IEnumerator DelayTeleport(Vector3 destination)
	{
		teleporting = true;
		gravityOn = false;
		Vector3 lastVelocity = rigidbody.velocity;
		rigidbody.velocity = Vector3.zero;
		yield return new WaitForSeconds(0.5f);
		Teleport(destination);
		yield return new WaitForSeconds(0.5f);
		UpdateVelocity(lastVelocity);
		gravityOn = true;
		teleporting = false;
	}

	public void TimeDilation(Vector3 center)
	{
		if(!dilating)
		{
			timeDilationCenter = center;
			timeDilationEntryVelocity = rigidbody.velocity;
			print (timeDilationEntryVelocity);
			dilating = true;
		}
	}

	public void EndTimeDilation()
	{
		timeDilationCenter = Vector3.zero;
		timeDilationFactor = 1.0f;
		rigidbody.velocity = timeDilationEntryVelocity;
		dilating = false;
	}
}
