using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ammunition on weapon
/// </summary>
public class Ammunition : MonoBehaviour
{

    private int _maxAmmo;
    private int _currentAmmo;

    private int _maxMag;
    private int _currentMag;

    public KeyCode ReloadWeaponKey;

    private bool _reloading;
    private float _reloadTime;

    public void Initialize(WeaponVariable weaponData)
    {
        _reloadTime = weaponData.ReloadTime;
        _maxAmmo = weaponData.MaxAmmoAmount;
        _maxMag = weaponData.MaxMagAmount;
        _currentAmmo = weaponData.AmmoToStartWith;
    }

    // Use this for initialization
    void Start()
    {
        _reloading = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(ReloadWeaponKey) && !_reloading)
        {
            StartCoroutine(Reloading());
        }
    }

    /// <summary>
    /// Reload ammunition
    /// </summary>
    public IEnumerator Reloading()
    {
        _reloading = true;

        var bulletsToReload = _maxMag - _currentMag;

        if (bulletsToReload == 0 || _currentAmmo == 0)
            yield break;

        yield return new WaitForSeconds(_reloadTime);

        if (_currentAmmo < bulletsToReload)
        {
            _currentMag += _currentAmmo;
            _currentAmmo = 0;
        }
        else
        {
            _currentMag += bulletsToReload;
            _currentAmmo -= bulletsToReload;
        }

        _reloading = false;

    }

    /// <summary>
    /// Add ammo to weapon
    /// </summary>
    /// <param name="amountAmmo"></param>
    public void AddAmmo(int amountAmmo)
    {
        if (_currentAmmo + amountAmmo > _maxAmmo)
            _currentAmmo = _maxAmmo;
        else
            _currentAmmo += amountAmmo;
    }
}
