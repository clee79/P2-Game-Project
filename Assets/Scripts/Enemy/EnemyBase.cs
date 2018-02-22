// Chris Lee
// Game Project 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

	public PlayerController player;
	protected float speed = 5f;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		Move();
	
	}

	// Base Enemy Move Command
	public abstract void Move ();

}
