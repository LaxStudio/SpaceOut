using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerShooter : BaseShooter
{
    [SerializeField]
    private int damage;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    private GameObject target;
    public FloatReference range;
    private List<GameObject> possibleTargets = new List<GameObject>();
    public List<StringVariable> targetTags;
    public GameObject projectile;

    override public void OnStart()
    {
        GetComponent<CircleCollider2D>().radius = range;
        myAnimator = transform.GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    override public Vector3 GetTarget()
    {
        if (HasTarget())
        {
            return target.GetComponent<Renderer>().bounds.center;
        }
        else
        {
            if(HasTarget())
            {
                return target.GetComponent<Renderer>().bounds.center;
            }
            else
            {
                
            }
            return target.GetComponent<Renderer>().bounds.center;
        }
    }

    private Boolean HasTarget()
    {
        Boolean value = target != null && target.GetComponent<Targetable>() != null;
        return value;
    }

    private void PickTarget() {

        GameObject bestTarget = target;

        if (this.possibleTargets.Count > 0)
        {
            bestTarget = this.possibleTargets[0];
        }

        this.target = bestTarget;
    }


    void Update()
    {
        if (HasTarget())
        {
            Shoot();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Targetable targetable = other.gameObject.GetComponent<Targetable>();
        if (targetable != null 
            && targetable.tags.All(item => targetTags.Contains(item)) 
            && !possibleTargets.Contains(other.gameObject))
        {
            possibleTargets.Add(other.gameObject);
        }

        PickTarget();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (target == other.gameObject)
        {
            possibleTargets.Remove(target);
            this.target = null;
        }

        else if (other.gameObject.tag == "Player" && 
            possibleTargets.Contains(other.gameObject))
        {
            possibleTargets.Remove(other.gameObject);
        }

        PickTarget();
    }

    public override Transform GetProjectile()
    {
        return projectile.transform;
    }
}
