// Chris Lee
// Game Project 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : EnemyBase
{
	float raylength = 150f;
	bool rayhit = false;

	void Awake ()
	{
		
	}
	
	void Update () 
	{
		Move ();

	}

	public override void Move ()
	{
		// Face the player
		// Cast a ray to the player, set rayhit to true.
		transform.LookAt(player.transform.position);
		if (Physics.Raycast(transform.position, transform.forward, raylength))
		{			
			rayhit = true;

			if (rayhit == true)
			{
				// Get distance from enemy to player.
				// Set new Vector3 for dist and normalize so movement isnt instant.
				float distance  = Vector3.Distance (transform.position, player.transform.position);
				Vector3 dist = player.transform.position - transform.position;
				dist.Normalize();

				// If more than 4 units away move.
				if(distance >= 4)
				{
					transform.position += (dist * (speed * 1.2f) * Time.deltaTime );
				}

				// No movement and reset raycast.
				else 
				{					
					rayhit = false;
				}
			}
		}
	}
}
