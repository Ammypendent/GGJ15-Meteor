using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeDilation : MonoBehaviour
{

	public List<GameObject> caughtAsteroids;

	public float lifetime;
	float spawnTime;
	public float radius;
	bool destruction;

	// Use this for initialization
	void Start()
	{
		destruction = false;
		caughtAsteroids = new List<GameObject>();
		spawnTime = Time.time;
		if(radius == 0)
		{
			radius = transform.localScale.x;
		}
		initialGrab();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Time.time - spawnTime > lifetime)
		{
			if(!destruction)
			{
				destruction = true;
				CustomGravity caughtScript;
				for(int i = 0; i < caughtAsteroids.Count; i++)
				{
					caughtScript = caughtAsteroids[i].gameObject.GetComponent<CustomGravity>();
					caughtScript.EndTimeDilation();
				}
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(!destruction)
		{
			caughtAsteroids.Add(other.gameObject);
			CustomGravity caughtScript = other.gameObject.GetComponent<CustomGravity>();
			caughtScript.TimeDilation(transform.position, radius);
		}
	}

	void OnTriggerExit(Collider other)
	{
		CustomGravity caughtScript = other.gameObject.GetComponent<CustomGravity>();
		caughtScript.EndTimeDilation();
		caughtAsteroids.Remove(other.gameObject);
	}

	void initialGrab()
	{
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag ("Asteroid");
		RaycastHit hit;
		CustomGravity otherScript;
		for(int i = 0; i < asteroids.Length; i++)
		{
			Ray ray = new Ray(transform.position, asteroids[i].transform.position);
			if(Physics.Raycast(ray, out hit, radius))
			{
				if(hit.collider.gameObject == asteroids[i])
				{
					caughtAsteroids.Add(hit.collider.gameObject);
					otherScript = hit.collider.gameObject.GetComponent<CustomGravity>();
					otherScript.TimeDilation(transform.position, radius);
				}
			}
		}
	}
}
