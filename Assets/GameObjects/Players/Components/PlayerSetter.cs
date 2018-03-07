using UnityEngine;

[
    RequireComponent(typeof(Mover)),
    RequireComponent(typeof(Inventory)),
]
public class PlayerSetter : MonoBehaviour
{
    public PlayerModel Model;
    
    void Start()
    {
        GetComponent<Mover>().Setup(Model.MoveSpeed);
        GetComponent<Inventory>().Setup(Model.InventorySize);
    }
}
