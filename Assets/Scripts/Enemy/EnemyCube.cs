﻿// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : EnemyBase
{
	private float raylength = 150f;
	private bool rayhit = false;   
    public Transform headshot;
    private float time;
    private float timeDelay = 0f;	

	public override void Move (Vector3 playerPosition)
	{        
		// Face the player
		// Cast a ray to the player, set rayhit to true.
		transform.LookAt(playerPosition);
		if (Physics.Raycast(transform.position, transform.forward, raylength))
		{			
			rayhit = true;

			if (rayhit == true)
			{
				// Get distance from enemy to player.
				// Set new Vector3 for dist and normalize so movement isnt instant.
				float distance  = Vector3.Distance (transform.position, playerPosition);
				Vector3 dist = playerPosition - transform.position;
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

    public override void Attack(Vector3 playerPosition)
    {
        
        if (player != null)
        {            
            time += Time.deltaTime;

            if (time > timeDelay)
            {
                // Check distance, update fire delay, fire shot if in range.                
                float check = Vector3.Distance(transform.position, playerPosition);
                if (check <= 20)
                {
                    timeDelay = time + 8.00f;
                    Instantiate(enemyshot, headshot.transform.position, transform.rotation);
                }
            }
        }
        
    }
}
