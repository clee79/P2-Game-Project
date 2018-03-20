// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

	public PlayerController player;
    public GameObject enemyshot;
	protected float speed = 5f;

	void Start () 
	{
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	

	void Update () 
	{		
	
	}

	// Base Enemy Move Command
	public abstract void Move (Vector3 playerPosition);
    public abstract void Attack(Vector3 playerPosition);

}
