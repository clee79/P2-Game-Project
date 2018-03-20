// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 7f;
	private float rotateY;
	private Rigidbody rb;
    public string currentWeapon;
	WeaponPistol pistol;
    WeaponMachineGun mgun;
    WeaponFlameThrower flamer;
	public Transform shotSpawn1, shotSpawn2, MGSpawn, FTSpawn, FTSpawn2, FTSpawm3;
    public GameObject shot;
    Inventory inventory;
    
	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
        // Makes a temp game object for setting up pistol
        // Assigns the temp to pistol.
        GameObject temp = GameObject.FindGameObjectWithTag("Pistol");
        pistol = temp.GetComponent<WeaponPistol>();
        mgun = GameObject.FindGameObjectWithTag("MG").GetComponent<WeaponMachineGun>();
        flamer = GameObject.FindGameObjectWithTag("Flamethrower").GetComponent<WeaponFlameThrower>();
        inventory = new Inventory();
        currentWeapon = null;
        
        inventory.AddToInventory(pistol);
        inventory.AddToInventory(mgun);
        inventory.AddToInventory(flamer);
        inventory.PrintInventory();              
        
    }
	

	void Update () 
	{
        // Set up keycommands for selecting weapon
        // 1 for pistol, 2 for machinegun, 3 for flamethrower.
        // Sets Pistol texture and shoot command to active.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = "Pistol";
            inventory.ActiveWeapon(pistol);            
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = "MG";
            inventory.ActiveWeapon(mgun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = "Flamethrower";
            inventory.ActiveWeapon(flamer);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Shoots pistol
            pistol.Shoot(shot, shotSpawn1, shotSpawn1, shotSpawn2);
            // Shoots machine gun
            mgun.Shoot(shot, MGSpawn, MGSpawn, MGSpawn);          
        } 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Shoots flamethrower
            flamer.Shoot(shot, FTSpawn, FTSpawn2, FTSpawm3);
        }
	}

	void FixedUpdate()
	{
		// Player move code 
		// Credit to Gesick lecture
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		rotateY += h * 5;
		if (rotateY > 360 || rotateY < -360)
			{
				rotateY = 0;
			}
		transform.rotation = Quaternion.Euler(0, rotateY, 0);

		if (v != 0)
		{
			rb.isKinematic = true;
			Vector3 velocity = transform.forward * speed * Time.deltaTime * v;
			transform.position += velocity;

            // Speed boost
			if (Input.GetKey(KeyCode.LeftShift))
			{
				transform.position += velocity * 1.25f;
			}

			if ( v == 0)
			{
				rb.isKinematic = false;
			}
		}		
	}   
}
