using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Bullet))]

public class TeleportBullet : MonoBehaviour
{
	public enum BType{Teleport, TimeDilation};
	public BType bulletType;
	public float effectRadius;
	public GameObject teleportObjectEntry;
	public GameObject teleportObjectExit;
	public GameObject timeDilationObject;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Asteroid")
		{
			GameObject[] asteroids = GameObject.FindGameObjectsWithTag ("Asteroid");
			RaycastHit hit;
			CustomGravity otherScript;
			for(int i = 0; i < asteroids.Length; i++)
			{
				Ray ray = new Ray(transform.position, (asteroids[i].transform.position - transform.position).normalized);
				if(Physics.Raycast(ray, out hit, effectRadius))
				{
					if(hit.collider.gameObject == asteroids[i])
					{
						otherScript = hit.collider.gameObject.GetComponent<CustomGravity>();
						if(bulletType == BType.Teleport)
						{
							//*** TODO!! -- ADD GRAPHICS ***
							//Instantiate(***TELEPORT POINT A***, transform.position, Quaternion.identity);
							//Instantiate(***TELEPORT POINT B***, new Vector3((hit.collider.transform.position.x * -1.0f) - (hit.collider.transform.position.normalized).x * 0.35f, hit.collider.transform.position.y + Random.Range(-0.125f, 0.125f), hit.collider.transform.position.z), Quaternion.identity);
							otherScript.Impact(new Vector3((hit.collider.transform.position.x * -1.0f) - (hit.collider.transform.position.normalized).x * 0.35f, hit.collider.transform.position.y + Random.Range(-12.5f, 12.5f), hit.collider.transform.position.z));
						}
//						else// if(bulletType == BType.TimeDilation)
//						{
//							//Instantiate(***TIME DILATION BUBBLE***, transform.position, Quaternion.identity);
//							Instantiate(timeDilationObject, transform.position, Quaternion.identity);
//						}
					}
				}
			}

//			if(bulletType == BType.Teleport)
//			{
//
//			}
//			else// if(bulletType == BType.TimeDilation)
			if(bulletType == BType.TimeDilation)
			{
				Instantiate(timeDilationObject, transform.position, Quaternion.identity);
			}
			
//			CustomGravity otherScript = other.gameObject.GetComponent<CustomGravity>();
//			otherScript.Impact(new Vector3 ((other.transform.position.x * -1.0f) - (other.transform.position.normalized).x * 0.2f, other.transform.position.y + Random.Range(-0.1f, 0.1f), other.transform.position.z));
			//otherScript.Teleport(new Vector3(other.transform.position.x * -1.2f, other.transform.position.y, other.transform.position.z));
			//otherScript.UpdateVelocity();
			Destroy(gameObject);
		}
//		GameObject[] asteroids = GameObject.FindGameObjectsWithTag ("Asteroid");
//		RaycastHit hit;
//		for(int i = 0; i < asteroids.Length; i++)
//		{
//			Ray ray = new Ray(transform.position, );
//		}
//
//
//		CustomGravity otherScript = other.gameObject.GetComponent<CustomGravity>();
//		otherScript.Impact(new Vector3 ((other.transform.position.x * -1.0f) - (other.transform.position.normalized).x * 0.2f, other.transform.position.y + Random.Range(-0.1f, 0.1f), other.transform.position.z));
//		//otherScript.Teleport(new Vector3(other.transform.position.x * -1.2f, other.transform.position.y, other.transform.position.z));
//		//otherScript.UpdateVelocity();
//		Destroy(gameObject);
	}

//	void UpdateVelocity(GameObject target)
//	{
//		target.rigidbody.velocity *= -0.5f;
//	}
//
//	void Teleport(GameObject target, Vector3 destination)
//	{
//		target.transform.position = destination;
//	}
}
