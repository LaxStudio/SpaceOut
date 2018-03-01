using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data for a weapon
/// </summary>
[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    [Tooltip("Avatar of the weapon, for inventory and such.")]
    public Sprite Avatar;

    [Tooltip("Interval of the fire rate.")]
    public FloatReference FireRate;

    [Tooltip("Damage that the weapon can do, each time it fires.")]
    public FloatReference Damage;

    [Tooltip("Causes players sprite to change to a different stance.")]
    public bool TwoHanded;
}