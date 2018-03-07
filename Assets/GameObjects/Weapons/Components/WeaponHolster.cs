using UnityEngine;

/// <summary>
/// Weapon inventory for a player
/// </summary>
public class WeaponHolster : MonoBehaviour {

    public GameObject ActiveWeapon { get; set; }
    
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
        weapon.transform.position = new Vector3(transform.position.x+0.7f, transform.position.y);
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
