using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    RequireComponent(typeof(Inventory))
]
public abstract class BaseMenuSpawner : MonoBehaviour {

    public Menu MenuPrefab;
    protected Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
        OnStart();
    }

    public abstract void OnStart();

    public abstract void SpawMenu(KeyCode menuKeyCode);
    

}
