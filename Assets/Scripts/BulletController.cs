﻿// Chris Lee
// Game Project 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	private float speed = 25f;
	public float factor = 1;
    public float time = 5f;
    PlayerController player;

	void Start ()
	{   
        GetComponent<Rigidbody>().velocity = transform.forward * speed * factor;        
		BulletTravel(Time);
	}

    public float Speed { get { return speed; } set { speed = value; } }
    public float Factor { get { return factor; } set { factor = value; } }
    public float Time { get { return time; }set { time = value; } }

    private void DestroybyTime ()
	{
		Destroy(gameObject);
	}

	// Destroy object if nothing hit and time passes.
	public void BulletTravel (float i)
	{			
		Destroy (gameObject,i);
	}

	// Bullet destruction on hit.
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Cube" || other.gameObject.tag == "BigBox" || other.gameObject.tag == "Boss")
		{                       
			Destroy(other.gameObject);
		}
        if (other.gameObject.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            if (player != null)
            {
                player.PlayerHealth -= 10;
            }
            
            Destroy(this.gameObject);
        }
	}
}
