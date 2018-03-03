using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShooter : MonoBehaviour {

    public GameObject projectile;
    private bool _hasFireRateCD;
    public FloatReference _fireRate;

    // Use this for initialization
    void Start ()
    {
        _hasFireRateCD = false;
        OnStart();
    }

    public abstract void OnStart();

    public abstract Boolean CanShoot();

    public abstract Vector3 GetTarget();

    // Update is called once per frame
    void Update ()
    {
        if (CanShoot() && !_hasFireRateCD)
        {
            StartCoroutine(Shoot(_fireRate));
        }
    }

    private IEnumerator Shoot(float fireRate)
    {
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
