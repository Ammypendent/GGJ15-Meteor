using UnityEngine;
using System.Collections;

public class PreviewAim : MonoBehaviour
{
	public GameObject trailPiecePrefab;
	GameObject[] trailPieces;
	float randomSpeed;

	// Use this for initialization
	void Start()
	{
		randomSpeed = Random.Range(0.85f, 1.15f);
		if(trailPiecePrefab == null)
		{
			Destroy(this);
		}

		trailPieces = new GameObject[10];
		for(int i = 0; i < trailPieces.Length; i++)
		{
			trailPieces[i] = Instantiate(trailPiecePrefab, transform.position, Quaternion.identity) as GameObject;
			trailPieces[i].transform.localEulerAngles = new Vector3(-90, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		float newColorValue = (Mathf.Sin(Time.time * randomSpeed) * 0.25f) + 0.75f;
		Color newColor = new Color(0, 1, 0, newColorValue);
		for(int i = 0; i < trailPieces.Length; i++)
		{
			trailPieces[i].transform.position = (transform.position * 1.5f) + (transform.position * i * 0.6f) + (transform.position * Mathf.Repeat(Time.time * randomSpeed, 1.0f) * 0.6f);
			newColor.a = newColorValue * (1.0f - ((float)i / (float)trailPieces.Length));
			trailPieces[i].renderer.material.SetColor("_Color", newColor);
		}
	}
}
