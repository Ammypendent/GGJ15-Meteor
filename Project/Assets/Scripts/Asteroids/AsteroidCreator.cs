using UnityEngine;
using System.Collections;

public class AsteroidCreator : MonoBehaviour {

	public GameObject Planet;
	public GameObject[] Asteroids;
	public int playerSide;
	private int currentSide;
	public int maxSpawnPerSide = 2;
	private int spawnThisSide;
	public float rangeY;
	public float distanceFromPlanet;


	//Attempting to create a pacing curve to control asteroid creation better
	private int[] pacing = {1,1,2,1,3,2,2,1,3,5,4,2,3,3,1,6,6,4,2,3,2};
	private int pacingPosition; 


	public float maxDelay;
	public float timer;
	float LastTimer;

	// Use this for initialization
	void Start () 
	{
		//Random side choosing
		int Roll = Random.Range (0, 8); //would setting max to 7 give make max roll 6?
		playerSide = Roll % 2 == 0 ? 1 : -1;

		gameObject.transform.position = new Vector3 (Planet.transform.position.x + (playerSide) * distanceFromPlanet, 0, 0);

		timer = Random.Range (0.2f, 3.5f);
		LastTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		LastTimer += Time.deltaTime;
		if (timer <= 0)
		{
			int AsteroidNumber = Random.Range(0, (Asteroids.Length));
			if (Asteroids[AsteroidNumber] != null)
			{
				Instantiate(Asteroids[AsteroidNumber], transform.position, Quaternion.identity);
				spawnThisSide++;
			}
			timer = Random.Range (0.2f, 3.5f) + Mathf.Max(maxDelay - LastTimer, 0.0f);
			LastTimer = 0.0f;
			SwitchPosition();
		}
	}

	/// <summary>
	/// Switchs the position of the Asteroid Creator after it spawns an asteroid.
	/// 
	/// </summary>
	void SwitchPosition ()
	{
		if (spawnThisSide >= maxSpawnPerSide)
		{
			//move to other side!
			playerSide *= -1;
			currentSide = playerSide;
			spawnThisSide = 0;
		}
		else
		{
			//Random side choosing
			int Roll = Random.Range (0, 8);
			playerSide = Roll % 2 == 0 ? 1 : -1;

			if (currentSide != playerSide)
			{
				spawnThisSide = 0;
				currentSide = playerSide;
			}
		}


		//Move the creator!
		Vector3 NewPosition = new Vector3 (Planet.transform.position.x + (playerSide) * distanceFromPlanet, Random.Range (-rangeY, rangeY), 0);
		gameObject.transform.position = NewPosition;
	}

	void GetPacing ()
	{

	}

}
