using UnityEngine;
using System.Collections;

public class AsteroidCreator : MonoBehaviour {

	public GameObject Planet;
	public GameObject[] Asteroids;
	public int PlayerSide;
	public float RangeY;
	public float DistanceFromPlanet;

	public float Timer;

	// Use this for initialization
	void Start () 
	{
		//Random side choosing
		int Roll = Random.Range (0, 8);
		PlayerSide = Roll % 2 == 0 ? 1 : -1;

		gameObject.transform.position = new Vector3 (Planet.transform.position.x + (PlayerSide) * DistanceFromPlanet, 0, 0);

		Timer = Random.Range (0.2f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Timer -= Time.deltaTime;
		if (Timer <= 0)
		{
			int AsteroidNumber = Random.Range(0, (Asteroids.Length));
			if (Asteroids[AsteroidNumber] != null)
			{
				Instantiate(Asteroids[AsteroidNumber]);
			}
			Timer = Random.Range (0.2f, 1.5f);
			SwitchPosition();
		}
	}

	/// <summary>
	/// Switchs the position of the Asteroid Creator after it spawns an asteroid.
	/// TODO: figure out how to semi-balance the randomness of the asteroids between
	/// players.
	/// </summary>
	void SwitchPosition ()
	{
		//Random side choosing
		int Roll = Random.Range (0, 8);
		PlayerSide = Roll % 2 == 0 ? 1 : -1;

		//Move the creator!
		Vector3 NewPosition = new Vector3 (Planet.transform.position.x + (PlayerSide) * DistanceFromPlanet, Random.Range (0.0f, RangeY), 0);
		gameObject.transform.position = NewPosition;
	}
}
