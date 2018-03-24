using UnityEngine;

/// <summary>
/// Weapon inventory for a player
/// </summary>
[
    RequireComponent(typeof(SpriteRenderer))
    RequireComponent(typeof(Inventory))
]
public class WeaponHolster : MonoBehaviour {

    public GameObject ActiveWeapon { get; set; }

    private SpriteRenderer _weaponCarrier;
    private float _playerHalfWidth;
    private Inventory _inventory;

    private void Start()
    {
        _weaponCarrier = GetComponent<SpriteRenderer>();
        _inventory = GetComponent<Inventory>();
        _playerHalfWidth = _weaponCarrier.bounds.size.x / 2;
    }

    
    public void Equip(GameObject weapon)
    {
        if(weapon == null || weapon.GetComponent<WeaponSetter>() == null)
        {
            return;
        }

        if(ActiveWeapon != null)
        {
            Drop();
        }

        var renderer = weapon.GetComponent<Renderer>();


        if (renderer != null)
        {
            renderer.enabled = true;
        }

        weapon.transform.parent = transform;

        var weaponHalfWidth = (renderer.bounds.size.x / 2);
        weapon.transform.localPosition = new Vector3(_playerHalfWidth + weaponHalfWidth, 0);
        weapon.layer = (int)GameLayers.Equipped;

        ActiveWeapon = weapon;
    }

    public void Drop()
    {
        if (ActiveWeapon == null)
        {
            return;
        }

        
        ActiveWeapon.transform.parent = null;
        ActiveWeapon.layer = (int)GameLayers.WorldItems;

        _inventory.RemoveItem(ActiveWeapon);
        ActiveWeapon = null;
    }

    public void Fire()
    {
        if(ActiveWeapon == null)
        {
            return;
        }

        var shooter = ActiveWeapon.GetComponent<WeaponShooter>();
        if(shooter == null)
        {
            return;
        }
        shooter.Shoot();
    }
}
