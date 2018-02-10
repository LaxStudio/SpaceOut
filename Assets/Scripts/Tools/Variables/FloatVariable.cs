using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Float")]
public class FloatVariable : ScriptableObject
{

    #if UNITY_EDITOR
        [Multiline(order = 3)]
        public string DeveloperDescription = "";
    #endif

    [Tooltip("Floats value")]
    public float Value;

    private float _value;

    public void SetValue(float value)
    {
        Value = value;
    }

    public void ApplyChange(float amount)
    {
        Value += amount;
    }
}
