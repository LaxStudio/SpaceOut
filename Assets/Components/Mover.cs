using System;
using UnityEngine;

/// <summary>
/// Setting up to move object with keyboard
/// Require Component attribute = Adds Rigitbody with black magic when this component is added
/// </summary>
[
    RequireComponent(typeof(Rigidbody2D)),
    RequireComponent(typeof(Animator)),
    RequireComponent(typeof(SpriteRenderer))
]
public class Mover : MonoBehaviour
{
    [Serializable]
    public class AnimationParameters
    {
        public string WalkUpParameterName;
        public string WalkDownParameterName;
        public string WalkSidewaysParameterName;
    }

    public FloatVariable MoveRate;
    public AnimationParameters AnimParameters;
    
    private Rigidbody2D _rb2d;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Move(bool up, bool down, bool right, bool left)
    {
        var vertical = (up ? 1 : 0) - (down ? 1 : 0);
        var horizontal = (right ? 1 : 0) - (left ? 1 : 0);
        var moveNormal = new Vector3(horizontal, vertical).normalized;
        SetAnimation(horizontal, vertical);
        var wantedPosition = transform.position + (moveNormal * Time.fixedDeltaTime * MoveRate.Value);
        _rb2d.MovePosition(wantedPosition);
    }

    private void SetAnimation(float horizontal, float vertical)
    {
        _animator.SetBool(AnimParameters.WalkSidewaysParameterName, horizontal > 0 || horizontal < 0);

        FlipSpriteChecker(horizontal);

        if (vertical > 0)
        {
            _animator.SetBool(AnimParameters.WalkUpParameterName, true);
            _animator.SetBool(AnimParameters.WalkDownParameterName, false);
        }
        else if (vertical < 0)
        {
            _animator.SetBool(AnimParameters.WalkUpParameterName, false);
            _animator.SetBool(AnimParameters.WalkDownParameterName, true);
        }
        else
        {
            _animator.SetBool(AnimParameters.WalkUpParameterName, false);
            _animator.SetBool(AnimParameters.WalkDownParameterName, false);
        }
    }

    private void FlipSpriteChecker(float horizontal)
    {
        if (horizontal < 0 && !_spriteRenderer.flipX || horizontal > 0 && _spriteRenderer.flipX)
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        
    }
}