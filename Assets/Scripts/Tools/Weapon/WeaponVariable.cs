﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data for a weapon
/// </summary>
[CreateAssetMenu]
public class WeaponVariable : ScriptableObject
{
    [Tooltip("Avatar of the weapon, for inventory and such.")]
    public Sprite Avatar;

    [Tooltip("Interval of the fire rate, in seconds")]
    public FloatReference FireRate;

    [Tooltip("Damage that the weapon can do, each time it fires.")]
    public FloatReference Damage;

    [Tooltip("Amount of bullets before reload.")]
    public float DefaultMagAmount;

    [Tooltip("Amount of bullets before reload.")]
    public float CurrentMagAmount; 

    [Tooltip("Causes players sprite to change to a different stance.")]
    public bool TwoHanded;

    [Tooltip("The projectile prefab.")]
    public Transform Projectile; // TODO change this to a scriptable object

    [Tooltip("Reload one bullet at the time.")]
    public bool ReloadOneBullet; // TODO fix reload weapon, one bullet at the time or the whole mag on reload

    [Tooltip("Reload one bullet at the time.")]
    public FloatReference ReloadSpeed; // TODO How long it takes to get full ammo

    //
    // For resetting the scriptable object
    //
    public void Reset()
    {
        CurrentMagAmount = DefaultMagAmount;
    }
}