using UnityEngine;
using System.Collections;

public class Ambient : MonoBehaviour {
		// Your light gameObject here.
		public Light light;
		
		// Array of random values for the intensity.
		private float[] smoothing = new float[20];
		private float startingIntensity;
		private float timer;
		private bool flickering = false;
		void Start(){
			// Initialize the array.
			for(int i = 0 ; i < smoothing.Length ; i++){
				smoothing[i] = .0f;
			}
			startingIntensity = light.intensity;
			timer = Time.time + Random.Range(30,60)/10;
		}
		
		void Update () {
			float sum = .0f;
			
			// Shift values in the table so that the new one is at the
			// end and the older one is deleted.
			for(int i = 1 ; i < smoothing.Length ; i++)
			{
				smoothing[i-1] = smoothing[i];
				sum+= smoothing[i-1];
			}
			
			// Add the new value at the end of the array.
			smoothing[smoothing.Length -1] = Random.value;
			sum+= smoothing[smoothing.Length -1];
			if (Time.time > timer) {
				flickering = !flickering;
				timer = Time.time + Random.Range(60,90)/10;
			}
			print (timer - Time.time);
			// Compute the average of the array and assign it to the
			// light intensity.
			if (flickering)
				light.intensity = sum / smoothing.Length;
			else
				light.intensity = startingIntensity;
	}
}
