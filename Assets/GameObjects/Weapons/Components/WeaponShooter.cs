using UnityEngine;

[RequireComponent(typeof(WeaponSetter))]
public class WeaponShooter : BaseShooter {

    private WeaponVariable _weapon;
    private bool _canShoot;
    
    public override void OnStart()
    {
        _weapon = GetComponent<WeaponSetter>().Weapon;
    }

    public override Vector3 GetTarget()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    public override Transform GetProjectile()
    {
        return _weapon.Projectile;
    }
}
