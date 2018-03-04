using System.Collections;
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
    public int MaxMagAmount;

    [Tooltip("Amount of bullets in total.")]
    public int MaxAmmoAmount;

    [Tooltip("Causes players sprite to change to a different stance.")]
    public bool TwoHanded;

    [Tooltip("The projectile prefab.")]
    public Transform Projectile;

    [Tooltip("Reload one bullet at the time.")]
    public bool ReloadOneBullet; // TODO fix reload weapon, one bullet at the time or the whole mag on reload

    [Tooltip("Reload one bullet at the time.")]
    public FloatReference ReloadTime; // TODO How long it takes to get full ammo

}