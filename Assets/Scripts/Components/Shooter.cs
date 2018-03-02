using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponHolster))]
public class Shooter : MonoBehaviour {

    private WeaponHolster _weaponHolster;
    private bool _canShoot;

    public KeyCode ShootKeyBinding;

    // Use this for initialization
    void Start ()
    {
        _canShoot = true;
        _weaponHolster = GetComponent<WeaponHolster>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(ShootKeyBinding) && _canShoot)
        {
            if(_weaponHolster.WeaponInventory.ActiveWeapon != null)
                StartCoroutine(ShootWeapon(_weaponHolster.WeaponInventory.ActiveWeapon.FireRate));
        }
    }

    private IEnumerator ShootWeapon(float fireRate)
    {
        var weapon = _weaponHolster.WeaponInventory.ActiveWeapon;

        if (weapon == null)
        {
            Debug.Log("No weapon equipped");
            yield break;
        }

        if (weapon.CurrentMagAmount < 1)
        {
            Debug.Log("Player need to reload");
            yield break;
        }

        var projectile = weapon.Projectile;
        var mouseInWorldCoordinates = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        var projectileTraveler = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Traveler>();
        projectileTraveler.SetDirectionWithTarget(mouseInWorldCoordinates);

        weapon.CurrentMagAmount -= 1;
        _canShoot = false;

        yield return new WaitForSeconds(fireRate);

        _canShoot = true;
    }
}
