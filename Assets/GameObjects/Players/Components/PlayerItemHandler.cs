using UnityEngine;
[
    RequireComponent(typeof(Collider2D)),
    RequireComponent(typeof(WeaponHolster)),
    RequireComponent(typeof(Inventory)),
]
public class PlayerItemHandler : MonoBehaviour
{
    private Collider2D _collider;
    private WeaponHolster _weaponHolster;
    private Inventory _inventory;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _weaponHolster = GetComponent<WeaponHolster>();
        _inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var item = collider.gameObject.GetComponent<ItemBase>();
        if (item != null)
        {
            item.Hover();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var item = collider.gameObject.GetComponent<ItemBase>();
        if (item != null)
        {
            item.UnHover();
        }
    }

    /// <summary>
    /// Handles pickup
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

            if (go.GetComponent<ItemBase>() == null)
            {
                return;
            }
            
            if (_inventory.AddItem(go))
            {
                var renderer = go.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = false;
                }
                
                var weapon = go.GetComponent<WeaponSetter>();
                if (weapon != null)
                {
                    _weaponHolster.Equip(go);
                }
            }
        }
    }
}
