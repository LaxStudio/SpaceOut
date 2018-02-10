using System;
using UnityEngine;

/// <summary>
/// Setting up to move object with keyboard
/// Require Component attribute = Adds Rigitbody with black magic when this component is added
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
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

    public FloatVariable MoveRate;
    public MoveAxis Horizontal = new MoveAxis(KeyCode.D, KeyCode.A);
    public MoveAxis Vertical = new MoveAxis(KeyCode.W, KeyCode.S);
    public Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var moveNormal = new Vector3(Horizontal, Vertical).normalized;
        var wantedPosition = transform.position + (moveNormal * Time.fixedDeltaTime * MoveRate.Value);
        rb2d.MovePosition(wantedPosition);
    }
}