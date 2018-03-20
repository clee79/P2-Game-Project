// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBoss : EnemyBase
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform bossShot;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override void Move(Vector3 playerPosition)
    {          
        agent.SetDestination(playerPosition);
    }

    public override void Attack(Vector3 playerPosition)
    {
        bossShot = GameObject.FindGameObjectWithTag("BSpawn").GetComponent<Transform>();
        float check = Vector3.Distance(transform.position, playerPosition);
        if (check <= 20)
        {            
            Instantiate(enemyshot, bossShot, bossShot);
        }
    }
}
