using UnityEngine;

[CreateAssetMenu]
public class PlayerModel : ScriptableObject
{
    [Tooltip("The speed of the player movement.")]
    public float MoveSpeed;

    [Tooltip("The inventory size.")]
    public int InventorySize;
}
