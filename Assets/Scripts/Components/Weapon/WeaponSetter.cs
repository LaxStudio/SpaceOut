﻿using UnityEngine;

/// <summary>
/// Like a constructor for Weapon GameObject
/// </summary>
public class WeaponSetter : MonoBehaviour {

    public Weapon Weapon;

    private SpriteRenderer _spriteRenderer;

	void Start () {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer != null)
            _spriteRenderer.sprite = Weapon.Avatar;
        
    }
}