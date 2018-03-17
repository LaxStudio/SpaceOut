using UnityEngine;

[
    RequireComponent(typeof(Mover)),
    RequireComponent(typeof(WeaponHolster)),
    RequireComponent(typeof(PlayerItemHandler))
    RequireComponent(typeof(MenuSpawner))
]
public class PlayerKeyBinder : MonoBehaviour
{
    public KeyCode DropWeaponKey = KeyCode.G;
    public KeyCode FireWeaponKey = KeyCode.Mouse0;
    public KeyCode SecondaryActionKey = KeyCode.Mouse1;
    public KeyCode PickUpKey = KeyCode.E;
    public KeyCode MoveUp = KeyCode.W;
    public KeyCode MoveDown = KeyCode.S;
    public KeyCode MoveRight = KeyCode.D;
    public KeyCode MoveLeft = KeyCode.A;

    private Mover _mover;
    private WeaponHolster _weaponHolster;
    private PlayerItemHandler _itemHandler;
    private MenuSpawner _menuSpawner;

    void Start()
    {
        _mover = GetComponent<Mover>();
        _weaponHolster = GetComponent<WeaponHolster>();
        _itemHandler = GetComponent<PlayerItemHandler>();
        _menuSpawner = GetComponent<MenuSpawner>();
    }

    void Update()
    {
        if (Input.GetKeyDown(DropWeaponKey))
        {
            _weaponHolster.Drop();
        }
        if (Input.GetKey(FireWeaponKey))
        {
            _weaponHolster.Fire();
        }
        if (Input.GetKeyDown(PickUpKey))
        {
            _itemHandler.Pickup();
        }

        if (Input.GetKeyDown(SecondaryActionKey))
        {
            _menuSpawner.SpawnMenu(SecondaryActionKey);
        }
    }

    private void FixedUpdate()
    {
        _mover.Move(
            Input.GetKey(MoveUp), 
            Input.GetKey(MoveDown), 
            Input.GetKey(MoveRight), 
            Input.GetKey(MoveLeft)
        );

    }
}
