using System;
using System.Collections;
using System.Collections.Generic;
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
        Boolean value = target != null
            && target.activeSelf
            && target.GetComponent<Renderer>() != null;
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

    override public Boolean CanShoot()
    {
        return HasTarget();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" &&
            !possibleTargets.Contains(other.gameObject))
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
}
