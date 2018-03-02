
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

    public KeyCode ReloadWeaponKey;

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

        if (Input.GetKeyDown(ReloadWeaponKey))
        {
            ReloadActiveWeapon();
        }
    }

    //
    // Add to inventory
    //
    public void AddWeapon(WeaponVariable weapon)
    {
        WeaponInventory.AddWeapon(weapon);
    }

    //
    // Drop active weapon from inventory, place it on player position
    //
    private void DropWeapon()
    {
        var droppedWeapon = WeaponInventory.DropWeapon();

        if (droppedWeapon != null)
        {
            WeaponPrefab.GetComponent<WeaponSetter>().Weapon = droppedWeapon;
            Instantiate(WeaponPrefab, this.transform.position, Quaternion.identity);
        }

    }

    //
    // Reload weapon
    //
    public void ReloadActiveWeapon()
    {
        WeaponInventory.ReloadActiveWeapon();
    }

}
