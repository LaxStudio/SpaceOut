using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {

    public Menu MenuPrefab;

    public void SpawnMenu(KeyCode menuKeyCode)
    {
        var menu = Instantiate(MenuPrefab) as Menu;
        menu.Initialize(menuKeyCode, transform);
    }

}
