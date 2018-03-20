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
                //i.Move(currentPos);
                //i.Attack(currentPos);
            }
        }
    }

    public void Spawn()
    {
        while (enemy.Count <= 8)
        {            
            int select = Random.Range(0, 3);
            Vector3 spawnlocation = new Vector3(Random.Range(-spawn.x, spawn.y), spawn.y, Random.Range(-spawn.z, spawn.z));
            Quaternion spawnquaterion = Quaternion.identity;
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
