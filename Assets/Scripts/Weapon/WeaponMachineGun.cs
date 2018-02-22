using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMachineGun : WeaponBase
{    

    public int Ammo { get { return ammo; } set { value = ammo; } }      

    void Start ()
    {
        this.ammo = 40;
        this.firerate = 5f;        
    }

    public override void Shoot(GameObject s, Transform a, Transform q, Transform x)
    {        
        if (isActive == true)
        {
            bullet.Speed = 20f;
            bullet.Factor = firerate;
            bullet.Time = 5f;
            if (ammo > 0)
            {
                // Set up call for weapon swap and new bullet spawn 
                // Add final class after those are done.
                Instantiate(s, a.transform.position, q.rotation);
                ammo--;
            }

            if (ammo == 0)
            {
                Reload(40, 0);
            }
        }
    }

    public override void Reload(int a1, int a2)
    {
        Debug.Log("Machine Gun Reloaded!");
        ammo += a1;
        
    }
}
