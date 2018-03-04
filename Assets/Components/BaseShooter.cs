using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShooter : MonoBehaviour
{
    private bool _hasFireRateCD;
    public float _fireRate = 1;

    // Use this for initialization
    void Start ()
    {
        _hasFireRateCD = false;
        OnStart();
    }

    public abstract void OnStart();

    public abstract Vector3 GetTarget();

    public abstract Transform GetProjectile();

    public void SetFireRate(float fireRate)
    {
        _fireRate = fireRate;
    }

    public void Shoot()
    {
        if (!_hasFireRateCD)
        {
            StartCoroutine(ShootLoop(_fireRate));
        }
    }

    private IEnumerator ShootLoop(float fireRate)
    {
        var projectile = GetProjectile();
        if (projectile == null)
        {
            Debug.Log("No projectile equipped");
            yield break;
        }

        var target = GetTarget();

        var newProjectile = Instantiate(projectile, transform.position, transform.rotation);
        newProjectile.GetComponent<Traveler>().SetDirectionWithTarget(target);

        _hasFireRateCD = true;

        yield return new WaitForSeconds(fireRate);

        _hasFireRateCD = false;
    }
}
