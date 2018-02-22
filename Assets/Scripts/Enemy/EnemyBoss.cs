// Chris Lee
// Game Project 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyBase
{
	UnityEngine.AI.NavMeshAgent nav;
	void Awake ()
	{
		
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update () 
	{
		Move();
	}

	public override void Move()
	{		
		// Enable mesh if false to start movement
		// Use Navmesh to set the destination as the players position.
		nav.enabled = true;
		nav.SetDestination(player.transform.position);

		// If close enough, disable navmesh movement
		if ( Vector3.Distance(transform.position, player.transform.position) <= 8)
		{
			nav.enabled = false;
		}
	}
}
