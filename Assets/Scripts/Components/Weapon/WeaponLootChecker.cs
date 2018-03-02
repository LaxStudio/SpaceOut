using System.Collections;
using System.Resources;
using UnityEngine;

/// <summary>
/// Set this component for a weapon to be lootable by a player
/// </summary>
[RequireComponent(typeof(WeaponSetter))]
public class WeaponLootChecker : MonoBehaviour
{

    public KeyCode PickUpKey;

    private Weapon _weapon;
    private WeaponHolster _activeHolster;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        var weaponData = GetComponent<WeaponSetter>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (weaponData != null && weaponData.Weapon != null)
            _weapon = weaponData.Weapon;

        _activeHolster = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(PickUpKey) && _activeHolster != null)
        {
            _activeHolster.AddWeapon(_weapon);
            Destroy(this.gameObject);
        }
    }

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (_weapon != null)
        {
            var possibleHolster = collider.GetComponent<WeaponHolster>();

            if (possibleHolster != null)
            {
                _activeHolster = possibleHolster;

                // add indicator to be picked up
                _spriteRenderer.color = Color.gray;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        var possibleHolster = collider.GetComponent<WeaponHolster>();
        if (possibleHolster != null && possibleHolster == _activeHolster)
        {
            _activeHolster = null;

            // remove indicator to be picked up
            _spriteRenderer.color = Color.white;
        }
    }

}
