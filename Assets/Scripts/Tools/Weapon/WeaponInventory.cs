using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponInventory : ScriptableObject
{
    public int MaxNumberOfWeapons;

    public Weapon ActiveWeapon;

    public List<Weapon> OwnedWeapons = new List<Weapon>();
    
    public void NextWeapon()
    {
        var currentIndex = OwnedWeapons.IndexOf(ActiveWeapon);
        var nextIndex = currentIndex + 1;

        if (nextIndex + 1 > OwnedWeapons.Count)
            nextIndex = 0;

        ActiveWeapon = OwnedWeapons[nextIndex];
    }

    public void PrevoiusWeapon()
    {
        var currentIndex = OwnedWeapons.IndexOf(ActiveWeapon);
        var previousIndex = currentIndex - 1;

        if (previousIndex < 0)
            previousIndex = OwnedWeapons.Count - 1;

        ActiveWeapon = OwnedWeapons[previousIndex];
    }

    public bool AddWeapon(Weapon weapon)
    {
        if(MaxNumberOfWeapons <= OwnedWeapons.Count)
        {
            OwnedWeapons.Add(weapon);
            return true;
        }

        return false;
    }
}