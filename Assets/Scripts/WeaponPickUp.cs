using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{

    public Vector3 weaponSpawns;
    public WeaponBase[] weapons;  

	void Start ()
    {        
        foreach (WeaponBase i in weapons)
        {
            Vector3 location = new Vector3(Random.Range(-weaponSpawns.x, weaponSpawns.x), weaponSpawns.y, Random.Range(-weaponSpawns.z, weaponSpawns.z));
            Quaternion locationq = Quaternion.identity;
            Instantiate(i, location, locationq);
        }
	}   


    void Update ()
    {
		
	}
}
