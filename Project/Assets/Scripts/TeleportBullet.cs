using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Bullet))]

public class TeleportBullet : MonoBehaviour
{

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
		CustomGravity otherScript = other.gameObject.GetComponent<CustomGravity>();
		otherScript.Impact(new Vector3 (other.transform.position.x * -1.2f, other.transform.position.y, other.transform.position.z));
		//otherScript.Teleport(new Vector3(other.transform.position.x * -1.2f, other.transform.position.y, other.transform.position.z));
		//otherScript.UpdateVelocity();
		Destroy(gameObject);
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
