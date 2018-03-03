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

    public WeaponVariable ActiveWeapon;

    public List<WeaponVariable> OwnedWeapons = new List<WeaponVariable>();

    //
    // For resetting the scriptable object
    //
    public void Reset()
    {
        MaxNumberOfWeapons = 5;
        ActiveWeapon = null;
        OwnedWeapons = new List<WeaponVariable>();
    }

    //
    // Select next weapon as active weapon
    //
    public void NextWeapon()
    {
        if (!OwnedWeapons.Any() || OwnedWeapons == null)
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
    public WeaponVariable AddWeapon(WeaponVariable weapon)
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
    public WeaponVariable DropWeapon()
    {
        var activeWeapon = ActiveWeapon;
        if (OwnedWeapons.Count > 0 && ActiveWeapon != null)
        {
            OwnedWeapons.Remove(activeWeapon);
            NextWeapon();
        }

        return activeWeapon;
    }

    public void ReloadActiveWeapon()
    {
        if (ActiveWeapon == null)
            return;

        //if (!ActiveWeapon.CurrentMagAmount.Equals(ActiveWeapon.DefaultMagAmount))
        //    ActiveWeapon.CurrentMagAmount = ActiveWeapon.DefaultMagAmount;

    }
}