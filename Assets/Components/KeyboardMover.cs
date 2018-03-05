using System;
using UnityEngine;

/// <summary>
/// Setting up to move object with keyboard
/// Require Component attribute = Adds Rigitbody with black magic when this component is added
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class KeyboardMover : MonoBehaviour
{
    [Serializable]
    public class MoveAxis
    {
        public KeyCode Positive;
        public KeyCode Negative;

        public MoveAxis(KeyCode positive, KeyCode negative)
        {
            Positive = positive;
            Negative = negative;
        }

        public static implicit operator float(MoveAxis axis)
        {
            return (Input.GetKey(axis.Positive)
                ? 1.0f : 0.0f) -
                (Input.GetKey(axis.Negative)
                ? 1.0f : 0.0f);
        }
    }

    [Serializable]
    public class AnimationParameters
    {
        public string WalkUpParameterName;
        public string WalkDownParameterName;
        public string WalkSidewaysParameterName;
    }

    public FloatVariable MoveRate;
    public MoveAxis Horizontal = new MoveAxis(KeyCode.D, KeyCode.A);
    public MoveAxis Vertical = new MoveAxis(KeyCode.W, KeyCode.S);
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

    private void FixedUpdate()
    {
        var moveNormal = new Vector3(Horizontal, Vertical).normalized;
        SetAnimation();
        var wantedPosition = transform.position + (moveNormal * Time.fixedDeltaTime * MoveRate.Value);
        _rb2d.MovePosition(wantedPosition);
    }

    private void SetAnimation()
    {

        _animator.SetBool(AnimParameters.WalkSidewaysParameterName, Horizontal > 0 || Horizontal < 0);

        FlipSpriteChecker();

        if (Vertical > 0)
        {
            _animator.SetBool(AnimParameters.WalkUpParameterName, true);
            _animator.SetBool(AnimParameters.WalkDownParameterName, false);
        }
        else if (Vertical < 0)
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

    private void FlipSpriteChecker()
    {
        if (Horizontal < 0 && !_spriteRenderer.flipX || Horizontal > 0 && _spriteRenderer.flipX)
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        
    }
}