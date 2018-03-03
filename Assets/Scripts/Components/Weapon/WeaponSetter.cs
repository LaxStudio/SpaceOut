using UnityEngine;

/// <summary>
/// Like a constructor for Weapon GameObject
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Ammunition))]
public class WeaponSetter : MonoBehaviour {

    public WeaponVariable Weapon;

    private SpriteRenderer _spriteRenderer;
    private Ammunition _ammo;

	void Start () {

        if(Weapon != null)
            Weapon.Reset();


        
        _spriteRenderer = GetComponent<SpriteRenderer>();
	    _ammo = GetComponent<Ammunition>();

        if (_ammo != null)
            _ammo.Initialize(Weapon.ReloadTime);

        if (_spriteRenderer != null)
            _spriteRenderer.sprite = Weapon.Avatar;
        
    }
}
