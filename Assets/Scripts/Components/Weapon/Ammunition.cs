using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{

    public int MaxAmmo;
    public int CurrentAmmo;

    public int MaxMag;
    public int CurrentMag;

    public KeyCode ReloadWeaponKey;

    private bool _reloading;
    private float _reloadTime;

    public void Initialize(float reloadTime)
    {
        _reloadTime = reloadTime;
    }

    // Use this for initialization
    void Start ()
	{
	    _reloading = false;
	}
	
	// Update is called once per frame
	void Update () {

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
        while (true)
        {
            var bulletsToReload = MaxMag - CurrentMag;

            if (bulletsToReload == 0 || CurrentAmmo == 0)
                yield break;

            yield return new WaitForSeconds(_reloadTime);

            if (CurrentAmmo < bulletsToReload)
            {
                CurrentMag += CurrentAmmo;
                CurrentAmmo = 0;
            }
            else
            {
                CurrentMag += bulletsToReload;
                CurrentAmmo -= bulletsToReload;
            }

            _reloading = false;
            break;
        }


    }
}
