// Chris Lee
// Game Project 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPistol : WeaponBase
{	
	private int pAmmo2 = 4;   	

    public int Ammo { get { return ammo; } set { value = ammo; } }
    public int PAmmo2 { get { return pAmmo2; } set { value = pAmmo2; } }     

    void Start()
    {
        this.ammo = 4;
        this.pAmmo2 = 4;
        this.firerate = 1f;        
    }


    // Remove passing the ammo value. 
    // ammo1 is the same as ammo from this class. Can use the variable inside this class and cutdown on whats passed.
    // also help with reload
    public override void Shoot (GameObject s, Transform a, Transform q, Transform x)
	{        
        if (isActive == true)
        {
            bullet.Speed = 20f;
            bullet.Factor = firerate;
            bullet.Time = 3f;
            // Setup shoot for gun A, and gun B.
            // Alternate Shooting each gun.
            if (ammo >= 0 && pAmmo2 >= 0)
            {
                if (ammo >= pAmmo2)
                {
                    Instantiate(s, a.transform.position, q.rotation);
                    ammo--;
                }

                else if (ammo < pAmmo2)
                {
                    Instantiate(s, x.transform.position, x.rotation);
                    pAmmo2--;
                    

                }
            }
            
            if (Ammo == 0 && PAmmo2 == 0)
            {
                Reload(4, 4);
            }
        }
	}
    

	public override void Reload (int a1, int a2)
	{
        Debug.Log("Pistols Reloaded!");       
		ammo += a1;
		pAmmo2 += a2;        
    }
}
