using System.Collections;
using UnityEngine;

/// <summary>
/// Set this component for a weapon to be lootable by a player
/// </summary>
[RequireComponent(typeof(WeaponSetter))]
public class WeaponLootChecker : MonoBehaviour
{

    private Weapon _weapon;
    private bool _lootable;

    private void Start()
    {
        var weaponData = GetComponent<WeaponSetter>();

        if(weaponData != null && weaponData.Weapon != null)
            _weapon = weaponData.Weapon;

        _lootable = false;
        StartCoroutine(SetLootable(1.0f));
    }

    private IEnumerator SetLootable(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            _lootable = true;
        }
    }

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (_weapon != null && _lootable)
        {
            var playerHolster = collider.GetComponent<WeaponHolster>();

            if (playerHolster != null)
            {
                playerHolster.AddWeapon(_weapon);
                Destroy(this.gameObject);
            }
        }
    }

}
