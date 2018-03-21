// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBoss : EnemyBase
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform bossShot;
    private float timeDelay = 0;
    private float time;
    private PlayerController playerRef;
    

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public override void Move(Vector3 playerPosition)
    {
        if (Vector3.Distance(transform.position, playerPosition) > 10f)
        {
            agent.SetDestination(playerPosition);
        }
    }

    public override void Attack(Vector3 playerPosition)
    {
        
        if (playerRef != null)
        {
            // Get time
            time += Time.deltaTime;

            // Compare delay for repeat shots
            if (time > timeDelay)
            {
                // Check distance, update fire delay, fire shot if in range.                
                float check = Vector3.Distance(transform.position, playerPosition);
                if (check <= 40)
                {
                    timeDelay = time + 5.00f;
                    Instantiate(enemyshot, bossShot.position, transform.rotation);
                }
            }
        }
       
    }
}
