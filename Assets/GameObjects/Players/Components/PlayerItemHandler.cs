using UnityEngine;
[
    RequireComponent(typeof(Collider2D)),
    RequireComponent(typeof(WeaponHolster)),
]
public class PlayerItemHandler : MonoBehaviour
{
    private Collider2D _collider;
    private WeaponHolster _weaponHolster;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _weaponHolster = GetComponent<WeaponHolster>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var item = collider.gameObject.GetComponent<Item>();
        if (item != null)
        {
            item.Hover();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var item = collider.gameObject.GetComponent<Item>();
        if (item != null)
        {
            item.UnHover();
        }
    }

    /// <summary>
    /// Handles pickup
    /// TODO make this to component
    /// </summary>
    public void Pickup()
    {
        var colliders = new Collider2D[10];
        var collitionCount = _collider.GetContacts(colliders);

        for (int i = 0; i < collitionCount; i++)
        {
            var collider = colliders[i];
            var go = collider.gameObject; //This is the game object you collided with
            if (go == gameObject) continue; //Skip the object itself

            //var item = go.GetComponent<Pickupable>();

            var weapon = go.GetComponent<WeaponSetter>();
            if (weapon != null)
            {
                _weaponHolster.Equip(go);
            }
        }
    }
}
