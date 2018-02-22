using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFlameThrower : WeaponBase
{

	// Use this for initialization
	void Start ()
    {
        this.ammo = 1000;
        this.firerate = 2.0f;        
    }

    public int Ammo { get { return ammo; } set { value = ammo; } }    
   
    public override void Shoot(GameObject s, Transform a, Transform q, Transform x)
    {
        if (isActive == true)
        {
            bullet.Factor = firerate;
            bullet.Speed = 750f;
            bullet.Time = .1f;

            if (ammo > 0 && ammo >= 3)
            {
                // Set up call for weapon swap and new bullet spawn 
                // Add final class after those are done.
                Instantiate(s, a.transform.position, a.rotation);
                Instantiate(s, q.transform.position, q.rotation);
                Instantiate(s, x.transform.position, x.rotation);
                ammo -= 3;
            }

            if(ammo == 0 || ammo < 3)
            {
                Reload(1000, 0);
            }
        }
    }

    public override void Reload(int a1, int a2)
    {
        Debug.Log("Flamethrower Reloaded!");
        ammo += a1;
        
    }
}
