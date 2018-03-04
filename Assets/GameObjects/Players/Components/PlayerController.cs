using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponHolster))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public KeyCode DropWeaponKey = KeyCode.G;
    public KeyCode FireWeaponKey = KeyCode.Mouse0;
    public KeyCode PickUpKey = KeyCode.E;

    private WeaponHolster _weaponHolster;
    private Collider2D _collider;

    void Start ()
    {
        _weaponHolster = GetComponent<WeaponHolster>();
        _collider = GetComponent<Collider2D>();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(DropWeaponKey))
        {
            _weaponHolster.Drop();
        }
        if (Input.GetKey(FireWeaponKey))
        {
            _weaponHolster.Fire();
        }
        if (Input.GetKeyDown(PickUpKey))
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        var colliders = new Collider2D[10];
        var collitionCount = _collider.GetContacts(colliders);

        for (int i = 0; i < collitionCount; i++)
        {
            var collider = colliders[i];
            var go = collider.gameObject; //This is the game object you collided with
            if (go == gameObject) continue; //Skip the object itself

            //var item = go.GetComponent<Pickupable>();

            var weapon = go.GetComponent<WeaponSetter>();
            if (weapon != null)
            {
                _weaponHolster.Equip(go);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // TODO refactor this to PickUpAbleItem
        var weapon = collider.gameObject.GetComponent<WeaponSetter>();
        if(weapon != null)
        {
            weapon.Highlight();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // TODO refactor this to PickUpAbleItem
        var weapon = collider.gameObject.GetComponent<WeaponSetter>();
        if (weapon != null)
        {
            weapon.UnHighlight();
        }
    }
}
