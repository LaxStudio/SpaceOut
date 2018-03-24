using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameObject[] _inventory;

    public bool IsInventoryFull { get { return Array.TrueForAll(_inventory, x => x != null); } }

    private bool _isInventoryEmpty { get { return Array.TrueForAll(_inventory, x => x == null); } }

    public bool AddItem(GameObject item)
    {
        if (IsInventoryFull)
        {
            return false;
        }

        var index = Array.FindIndex(_inventory, x => x == null);
        
        if (index == -1)
        {
            return false;
        }

        _inventory[index] = item;

        return true;
    }

    public bool RemoveItem(GameObject item)
    {
        var index = Array.FindIndex(_inventory, x => Equals(x, item));
        if(index == -1)
        {
            return false;
        }

        _inventory[index] = null;

        return true;
    }

    public void Setup(int inventorySize)
    {
        _inventory = new GameObject[inventorySize];
    }

    public GameObject[] GetWeapons()
    {
        if (_isInventoryEmpty)
            return null;

       return Array.FindAll(_inventory, x => x != null && x.GetComponent<WeaponSetter>() != null);
    }
}
