// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigBox : EnemyBase 
{
	void Update () 
	{
        //Move(player.transform.position);
    }

	public override void Move (Vector3 playerPosition)
	{
		// Face the player
		float sd = speed * Time.deltaTime;
		//transform.LookAt(player.transform.position);

		// Check the distance to the player, if within 6 units hold position
		if ( Vector3.Distance(transform.position, playerPosition) >= 8 )
		{
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, sd);

		}

	}

    public override void Attack(Vector3 playerPosition)
    {
        
    }
}
