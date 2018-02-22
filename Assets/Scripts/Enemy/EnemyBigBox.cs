// Chris Lee
// Game Project 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigBox : EnemyBase 
{
	void Update () 
	{
		Move ();
	}

	public override void Move ()
	{
		// Face the player
		float sd = speed * Time.deltaTime;
		transform.LookAt(player.transform.position);

		// Check the distance to the player, if within 6 units hold position
		if ( Vector3.Distance(transform.position, player.transform.position) >= 8 )
		{
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, sd);

		}

	}
}
