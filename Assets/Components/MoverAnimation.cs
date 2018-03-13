using System;
using UnityEngine;

[
    RequireComponent(typeof(Animator)),
    RequireComponent(typeof(SpriteRenderer)),
    RequireComponent(typeof(Mover))
]
public class MoverAnimation : MonoBehaviour
{
    [Serializable]
    public class AnimationParameters
    {
        public AnimationClip WalkUpParameterName;
        public AnimationClip WalkDownParameterName;
        public AnimationClip WalkSidewaysParameterName;
    }

    [SerializeField]
    private AnimationParameters _animParameters;

    private Mover _mover;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start ()
	{
	    _animator = GetComponent<Animator>();
	    _spriteRenderer = GetComponent<SpriteRenderer>();
	    _mover = GetComponent<Mover>();
	    _mover.OnMove(AnimateMove);
	}

    /// <summary>
    /// mover.x = horizontal
    /// mover.y = vertical
    /// </summary>
    /// <param name="mover"></param>
    public void AnimateMove(Vector2 mover)
    {
        _animator.SetBool(_animParameters.WalkSidewaysParameterName.name, mover.x > 0 || mover.x < 0);

        FlipSpriteChecker(mover.x);

        if (mover.y > 0)
        {
            _animator.SetBool(_animParameters.WalkUpParameterName.name, true);
            _animator.SetBool(_animParameters.WalkDownParameterName.name, false);
        }
        else if (mover.y < 0)
        {
            _animator.SetBool(_animParameters.WalkUpParameterName.name, false);
            _animator.SetBool(_animParameters.WalkDownParameterName.name, true);
        }
        else
        {
            _animator.SetBool(_animParameters.WalkUpParameterName.name, false);
            _animator.SetBool(_animParameters.WalkDownParameterName.name, false);
        }
    }

    private void FlipSpriteChecker(float horizontal)
    {
        if (horizontal < 0 && !_spriteRenderer.flipX || horizontal > 0 && _spriteRenderer.flipX)
            _spriteRenderer.flipX = !_spriteRenderer.flipX;

    }
}
