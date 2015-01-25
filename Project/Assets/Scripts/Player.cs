using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum id
	{
		PlayerRight,
		PlayerLeft
	}
	public id player;
	

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Asteroid")
		{
			if (player == id.PlayerLeft)
			{
				Global.playerOneHealth--;
				if (Global.playerOneHealth <= 0)
				{
					Global.EndGame();
				}
			}
			else if (player == id.PlayerRight)
			{
				Global.playerTwoHealth--;
				if (Global.playerTwoHealth <=0)
				{
					Global.EndGame();
				}
			}

			Destroy(collider.gameObject);
		}
	}
}
