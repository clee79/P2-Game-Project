// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public List<EnemyBase> enemy;
    public PlayerController player;
    public Vector3 spawn;
    public EnemyBase[] enemies;
    public int spawncount;


    void Start ()
    {        
        enemy = new List<EnemyBase>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Spawn();
	}
	
	
	void Update ()
    {
        Vector3 currentPos = player.transform.position;
        foreach (EnemyBase i in enemy)
        {
            if (i != null)
            {
                i.Move(currentPos);
                i.Attack(currentPos);
            }
        }
    }

    public void Spawn()
    {
        // Spawn enemies until spawncount met.
        while (enemy.Count <= spawncount)
        {
            // Pick an enemy type then assign a random range.
            int select = Random.Range(0, 3);
            Vector3 spawnlocation = new Vector3(Random.Range(-spawn.x, spawn.x), spawn.y, Random.Range(-spawn.z, spawn.z));

            // if the random location is to close the player, while loop defines new spawn
            while (Vector3.Distance(spawnlocation,player.transform.position) <= 30 )
            {
                spawnlocation = new Vector3(Random.Range(-spawn.x, spawn.x)+2, spawn.y, Random.Range(-spawn.z, spawn.z)+2);
            }
            Quaternion spawnquaterion = Quaternion.identity;

            // Based on random selection, spawn enemy type and add to list of enemy.
            if (select == 0)
            {
                enemy.Add((EnemyCube)Instantiate(enemies[0], spawnlocation, spawnquaterion));                
            }
            else if (select == 1)
            {
                enemy.Add((EnemyBigBox)Instantiate(enemies[1], spawnlocation, spawnquaterion));
            }
            else if (select == 2)
            {
                enemy.Add((EnemyBoss)Instantiate(enemies[2], spawnlocation, spawnquaterion));
            }
            else
            {
                // Debug check for mob type selection
                Debug.Log("Error: Select mob out of range: " + select);
            }
        }
    }
}
