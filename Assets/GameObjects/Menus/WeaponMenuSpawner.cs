using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponHolster))]
public class WeaponMenuSpawner : BaseMenuSpawner
{

    private WeaponHolster _weaponHolster;
    
    public override void OnStart()
    {
        _weaponHolster = GetComponent<WeaponHolster>();
    }

    public override void SpawMenu(KeyCode menuKeyCode)
    {
        var weapons = _inventory.GetWeapons();

        if (_inventory == null || weapons == null)
            return;
        
        MenuAction[] buttons = new MenuAction[weapons.Length];

        for(var i = 0; i<weapons.Length; i++)
        {
            var weapon = weapons[i];
            var weaponSetter = weapon.GetComponent<WeaponSetter>();

            if(weapon != null)
            {
                buttons[i] = new MenuAction
                {
                    ButtonAction = () => _weaponHolster.Equip(weapon),
                    Title = weaponSetter.Weapon.name,
                    Sprite = weaponSetter.Weapon.Avatar,
                    Color = Color.white
                };
            }
        }

        var menu = Instantiate(MenuPrefab) as Menu;
        menu.Initialize(menuKeyCode, transform, buttons);
    }
}
