using UnityEngine;
using System.Collections;

public class CutScene : MonoBehaviour {

	public MovieTexture movTexture;
	private AudioClip music;

	// Use this for initialization
	void Start () {

		renderer.material.mainTexture = movTexture;
		audio.clip = movTexture.audioClip;

		movTexture.Play();
		audio.Play ();

		Invoke ("destructor", movTexture.duration);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void destructor()
	{
		Destroy (gameObject);
	}

}
