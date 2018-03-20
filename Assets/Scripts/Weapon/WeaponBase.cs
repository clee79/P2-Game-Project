// Chris Lee
// Game Project 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour 
{
	public PlayerController player;
    public BulletController bullet;
	protected int ammo = 6;
	protected float firerate = 1.25f;
    public bool isActive;
    public bool isPickedup;

    public WeaponBase()
    {
             
    }  
    
	public abstract void Shoot (GameObject s, Transform a, Transform m, Transform x);
	public abstract void Reload (int a1, int a2);
}
