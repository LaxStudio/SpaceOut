using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponHolster))]
public class Shooter : MonoBehaviour {

    private WeaponHolster weaponHolster;

    public KeyCode ShootKeyBinding;

    // Use this for initialization
    void Start () {
        weaponHolster = GetComponent<WeaponHolster>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(ShootKeyBinding))
        {
            ShootWeapon();
        }
    }

    private void ShootWeapon()
    {
        Weapon weapon = weaponHolster.WeaponInventory.ActiveWeapon;
        if(weapon == null)
        {
            Debug.Log("No weapon equipped");
            return;
        }

        var projectile = weapon.Projectile;
        Vector3 mouseInWorldCoordinates = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        var projectileTraveler = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Traveler>();
        projectileTraveler.SetDirectionWithTarget(mouseInWorldCoordinates);
    }
}
