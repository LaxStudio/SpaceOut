﻿
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Weapon inventory for a player
/// </summary>
public class WeaponHolster : MonoBehaviour {

    //
    // Players inventory
    //
    public WeaponInventory WeaponInventory;

    //
    // Default weapon
    //
    public GameObject WeaponPrefab;

    //
    // Press 'Drop Weapon button' for drop
    //
    public KeyCode DropWeaponKey;

    private void Start()
    {
        //
        // Reset the inventory, reset somewhere else later
        //
        WeaponInventory.Reset();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(DropWeaponKey))
        {
            DropWeapon();
        }
    }

    //
    // Add to inventory
    //
    public void AddWeapon(Weapon weapon)
    {
        WeaponInventory.AddWeapon(weapon);
    }

    //
    // Drop active weapon from inventory, place it on player position
    //
    private void DropWeapon()
    {
        var droppedWeapon = WeaponInventory.DropWeapon();
        WeaponPrefab.GetComponent<WeaponSetter>().Weapon = droppedWeapon;
        WeaponPrefab.GetComponent<Rigidbody2D>().AddForce(-transform.right * 500);
        Instantiate(WeaponPrefab, this.transform.position, Quaternion.identity);

    }

}