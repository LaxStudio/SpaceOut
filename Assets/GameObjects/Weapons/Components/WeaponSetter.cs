using UnityEngine;

/// <summary>
/// Like a constructor for Weapon GameObject
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Ammunition))]
[RequireComponent(typeof(WeaponShooter))]
public class WeaponSetter : MonoBehaviour {

    public WeaponVariable Weapon;

    private SpriteRenderer _spriteRenderer;
    private Ammunition _ammo;

	void Start () {

	    if (Weapon == null)
	    {
            Debug.Log("Weapon not connected to WeaponSetter");
	        return;
	    }

        _spriteRenderer = GetComponent<SpriteRenderer>();
	    _ammo = GetComponent<Ammunition>();

        if (_ammo != null)
            _ammo.Initialize(Weapon.ReloadTime, Weapon.MaxAmmoAmount, Weapon.MaxMagAmount);

        if (_spriteRenderer != null)
            _spriteRenderer.sprite = Weapon.Avatar;

        var shooter = GetComponent<WeaponShooter>();
        shooter.SetFireRate(Weapon.FireRate);
    }

    public void Highlight()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public void UnHighlight()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
