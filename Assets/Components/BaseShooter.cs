using System.Collections;
using UnityEngine;

public abstract class BaseShooter : MonoBehaviour
{
    private bool _hasFireRateCD;
    private float _shooterWidth; 

    public float _fireRate = 1;

    // Use this for initialization
    void Start ()
    {
        var renderer = GetComponent<Renderer>();

        if (renderer != null)
            _shooterWidth = renderer.bounds.size.x;

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

        //
        // spawn projectile at the end of the shooter
        //
        var projectilePosition = new Vector2(transform.position.x + (_shooterWidth / 2), transform.position.y);
        var newProjectile = Instantiate(projectile, projectilePosition, transform.rotation);
        newProjectile.GetComponent<Traveler>().SetDirectionWithTarget(target);

        _hasFireRateCD = true;

        yield return new WaitForSeconds(fireRate);

        _hasFireRateCD = false;
    }
}
