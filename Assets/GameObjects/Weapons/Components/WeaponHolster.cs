using UnityEngine;

/// <summary>
/// Weapon inventory for a player
/// </summary>
[
    RequireComponent(typeof(SpriteRenderer))
]
public class WeaponHolster : MonoBehaviour {

    public GameObject ActiveWeapon { get; set; }

    private SpriteRenderer _weaponCarrier;
    private float _playerHalfWidth;

    private void Start()
    {
        _weaponCarrier = GetComponent<SpriteRenderer>();
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
        var weaponHalfWidth = (renderer.bounds.size.x / 2);
        if (renderer != null)
        {
            renderer.enabled = true;
        }

        weapon.transform.parent = transform;
        

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
