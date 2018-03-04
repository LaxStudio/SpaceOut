using UnityEngine;

[CreateAssetMenu(menuName = "Simple Projectile")]
public class SimpleProjectileModel : ScriptableObject
{
    [Tooltip("Travel speed")]
    public float TravelSpeed;
    public float TravelDistance;
    public float DamageApplier;

}
