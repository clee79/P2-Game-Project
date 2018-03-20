// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : EnemyBase
{
	private float raylength = 150f;
	private bool rayhit = false;
    private float attackrange = 5f;
    public Transform headshot;

	void Awake ()
	{
        headshot = GameObject.FindGameObjectWithTag("HSpawn").GetComponent<Transform>();
	}
	
	void Update () 
	{
        // remove these after debugging.
        Move(player.transform.position);
        Attack(player.transform.position);
	}

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
        // Cast a ray to check if in attack range
        // if (Physics.Raycast(transform.position, transform.forward, attackrange) == true )  

        // Headshot is not spawnning in the correct location.
        // Even though the position is held by the parent it is not properlly updating to the game.
        // All shot are fired from 0,0,0.
            headshot = GetComponentInChildren<Transform>();
            float check = Vector3.Distance(transform.position, playerPosition);
            if (check <= 20)
            {            
                Instantiate(enemyshot, headshot, headshot);
            }
        
    }
}
