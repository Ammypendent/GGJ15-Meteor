﻿using UnityEngine;
using System.Collections;

public class TimeBullet : MonoBehaviour 
{
	private GameObject self;
	public int maximumDistance;
	private float cleanupTimer;
	
	// Use this for initialization
	void Start () {
		cleanupTimer = 2.5f;
		self = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position != Vector3.zero) 
		{
			this.transform.position = new Vector3 (this.transform.position.normalized.x * 0.01f + this.transform.position.x, 
			                                       this.transform.position.normalized.y * 0.01f + this.transform.position.y, 
			                                       this.transform.position.normalized.z * 0.01f + this.transform.position.z);
			
		}
		
		cleanupTimer-= Time.deltaTime;
		if (cleanupTimer <= 0)
		{
			Destroy(self);
		}
	}

}
