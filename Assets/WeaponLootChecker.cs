using UnityEngine;

public class WeaponLootChecker : MonoBehaviour
{

    public Weapon Weapon;

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (Weapon != null)
        {
            var playerHolster = collider.GetComponent<WeaponHolster>();

            if (playerHolster != null)
            {
                playerHolster.AddWeapon(Weapon);
                Destroy(gameObject);
            }
        }
    }

}
