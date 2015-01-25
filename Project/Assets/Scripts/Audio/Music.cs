using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioClip slow;
	public AudioClip medium;
	public AudioClip fast;

	// Use this for initialization
	void Start () {
		audio.PlayOneShot (slow, 1f);
		Invoke ("playMusic", slow.length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playMusic()
	{
		if (Global.playerOneHealth < Global.fastMusic || Global.playerTwoHealth < Global.fastMusic) 
		{
			audio.PlayOneShot (fast, 1f);
			Invoke ("playMusic", fast.length);
		} else if (Global.playerOneHealth < Global.mediumMusic || Global.playerTwoHealth < Global.mediumMusic)
		{
			audio.PlayOneShot (medium, 1f);
			Invoke ("playMusic", medium.length);
		}
		else
		{
			audio.PlayOneShot (slow, 1f);
			Invoke ("playMusic", slow.length);
		}
	}
}
