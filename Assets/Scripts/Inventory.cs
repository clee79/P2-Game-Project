// Chris Lee
// Game Project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
    {

    public List <WeaponBase> weapon;
    PlayerController player;

	public  Inventory()
    {
        weapon = new List<WeaponBase>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void AddToInventory(WeaponBase t)
    {
        weapon.Add(t);
        t.gameObject.SetActive(false);
        t.isActive = false;        
    }

    public void ActiveWeapon(WeaponBase w)
    {
        // Turns on gun for selected object.
        w.gameObject.SetActive(true);
        w.isActive = true;        

        // Disable unselected guns.
        if (w.gameObject.tag == player.currentWeapon)
        {
            foreach (WeaponBase i in weapon)
            {
                if (i == w)
                {
                    continue;
                }
                else
                {
                    if (i.isActive == true)
                    {
                        i.isActive = false;
                    }

                    if (i.gameObject.activeSelf == true)
                    {
                        i.gameObject.SetActive(false);
                    }                 
                    
                }
                    
            }
        }
    }      

    public void PrintInventory()
    {
        int count = 1;
        string s = (" Weapon # " + count + " ");
        foreach (WeaponBase i in weapon)
        {
            s += i;
            count++;
            Debug.Log(s);
            s = (" Weapon # " + count + " ");
        }
        
    }

}
