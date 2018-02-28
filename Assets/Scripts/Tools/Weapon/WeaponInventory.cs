using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class WeaponInventory : ScriptableObject
{
    public int MaxNumberOfWeapons;

    public Weapon ActiveWeapon;

    public List<Weapon> OwnedWeapons = new List<Weapon>();

    public void NextWeapon()
    {
        if (!OwnedWeapons.Any())
        {
            ActiveWeapon = null;
            return;
        }
            
        var currentIndex = OwnedWeapons.IndexOf(ActiveWeapon);
        var nextIndex = currentIndex + 1;

        if (nextIndex + 1 > OwnedWeapons.Count)
            nextIndex = 0;

        ActiveWeapon = OwnedWeapons[nextIndex];
    }

    public void PrevoiusWeapon()
    {
        if (!OwnedWeapons.Any())
        {
            ActiveWeapon = null;
            return;
        }
            
        var currentIndex = OwnedWeapons.IndexOf(ActiveWeapon);
        var previousIndex = currentIndex - 1;

        if (previousIndex < 0)
            previousIndex = OwnedWeapons.Count - 1;

        ActiveWeapon = OwnedWeapons[previousIndex];
    }

    public Weapon AddWeapon(Weapon weapon)
    {
        if (MaxNumberOfWeapons <= OwnedWeapons.Count)
        {
            OwnedWeapons.Add(weapon);
            ActiveWeapon = weapon;
        }

        return weapon;
    }

    public Weapon DropWeapon()
    {

        var activeWeapon = ActiveWeapon;
        if (OwnedWeapons.Count > 0 && ActiveWeapon != null)
        {
            OwnedWeapons.Remove(activeWeapon);
            NextWeapon();
        }

        Debug.Log(activeWeapon.ToString());
        return activeWeapon;
    }
}