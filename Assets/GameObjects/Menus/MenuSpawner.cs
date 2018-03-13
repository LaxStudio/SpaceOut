using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {

    public static MenuSpawner Instance;
    public Menu menuPrefab;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    
    public void SpawnMenu(MenuInteractable obj)
    {
        var menu = Instantiate(menuPrefab) as Menu;
        menu.transform.SetParent(transform, false);
        menu.transform.position = Input.mousePosition;
        menu.SpawnButtons(obj);
        menu.TextLabel.text = obj.Title.ToUpper();


    }

}
