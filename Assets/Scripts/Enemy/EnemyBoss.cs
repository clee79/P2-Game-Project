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
    

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
        // Get time
        time += Time.deltaTime;
        
        // Compare delay for repeat shots
        if (time > timeDelay)
        {
            // Update delay, check distance, fire shot if in range.
            timeDelay = time + 5.00f;
            float check = Vector3.Distance(transform.position, playerPosition);
            Quaternion qcheck = Quaternion.identity;
            if (check <= 25)
            {
                Instantiate(enemyshot, bossShot.transform.position, qcheck);
            }
        }
    }
}
