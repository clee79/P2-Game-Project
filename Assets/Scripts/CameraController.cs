// Chris Lee
// Game Project 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public PlayerController player;
	private Vector3 offset;

	void Start () 
	{
		offset = transform.position - player.transform.position;
	}
	

	void Update () 
	{
		transform.position = player.transform.position + offset;
	}
}
