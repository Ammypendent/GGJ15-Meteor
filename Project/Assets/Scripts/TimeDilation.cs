using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeDilation : MonoBehaviour
{

	public List<GameObject> caughtAsteroids;

	// Use this for initialization
	void Start()
	{
		caughtAsteroids = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		print (other.name);
		caughtAsteroids.Add(other.gameObject);
		CustomGravity caughtScript = other.gameObject.GetComponent<CustomGravity>();
		caughtScript.TimeDilation(transform.position);
	}

	void OnTriggerExit(Collider other)
	{
		CustomGravity caughtScript = other.gameObject.GetComponent<CustomGravity>();
		caughtScript.EndTimeDilation();
		caughtAsteroids.Remove(other.gameObject);
	}
}
