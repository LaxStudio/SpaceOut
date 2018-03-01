
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolster : MonoBehaviour {

    public WeaponInventory WeaponInventory;

    public KeyCode DropWeapon;

    private void Start()
    {
        WeaponInventory.OwnedWeapons = new List<Weapon>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(DropWeapon))
        {
            var droppedWeapon = WeaponInventory.DropWeapon();
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        WeaponInventory.AddWeapon(weapon);
    }

}
