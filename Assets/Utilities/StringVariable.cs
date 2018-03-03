using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "String")]
public class StringVariable : ScriptableObject
{

    #if UNITY_EDITOR
        [Multiline(order = 3)]
        public string DeveloperDescription = "";
    #endif

    [Tooltip("String value")]
    public float Value;
}
