using System;
using UnityEngine;

/// <summary>
/// Setting up to move object with keyboard
/// Require Component attribute = Adds Rigitbody with black magic when this component is added
/// </summary>
[
    RequireComponent(typeof(Rigidbody2D)),
]
public class Mover : MonoBehaviour
{

    private float _moveRate;
    private Rigidbody2D _rb2d;
    private Action<Vector2> _onMoveEvent;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void Setup(float moveSpeed)
    {
        _moveRate = moveSpeed;
    }
    
    public void Move(bool up, bool down, bool right, bool left)
    {
        var vertical = (up ? 1 : 0) - (down ? 1 : 0);
        var horizontal = (right ? 1 : 0) - (left ? 1 : 0);
        var moveNormal = new Vector3(horizontal, vertical).normalized;
        var wantedPosition = transform.position + (moveNormal * Time.fixedDeltaTime * _moveRate);
        _rb2d.MovePosition(wantedPosition);

        if (_onMoveEvent != null)
        {
            _onMoveEvent(moveNormal);
        }
    }

    public void OnMove(Action<Vector2> animateMove)
    {
        _onMoveEvent = animateMove;
    }
}