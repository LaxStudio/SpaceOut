using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Data for players inventory
/// </summary>
[CreateAssetMenu]
public class WeaponInventory : ScriptableObject
{
    public int MaxNumberOfWeapons;

    public Weapon ActiveWeapon;

    public List<Weapon> OwnedWeapons = new List<Weapon>();

    //
    // For resetting the scriptable object
    //
    public void Reset()
    {
        MaxNumberOfWeapons = 5;
        ActiveWeapon = null;
        OwnedWeapons = new List<Weapon>();
    }

    //
    // Select next weapon as active weapon
    //
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

    //
    // Select previous weapon as active weapon
    //
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

    //
    // Add weapon to inventory
    //
    public Weapon AddWeapon(Weapon weapon)
    {
        if (MaxNumberOfWeapons > OwnedWeapons.Count)
        {
            OwnedWeapons.Add(weapon);
            ActiveWeapon = weapon;
        }

        return weapon;
    }

    //
    // Remove weapon from inventory
    //
    public Weapon DropWeapon()
    {
        var activeWeapon = ActiveWeapon;
        if (OwnedWeapons.Count > 0 && ActiveWeapon != null)
        {
            OwnedWeapons.Remove(activeWeapon);
            NextWeapon();
        }

        return activeWeapon;
    }
}