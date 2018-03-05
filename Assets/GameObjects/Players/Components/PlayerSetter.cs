using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PlayerSetter : MonoBehaviour
{
    public PlayerModel Model;

    private Mover _mover;

    void Start()
    {
        _mover = GetComponent<Mover>();

        _mover.Setup(Model.MoveSpeed);
    }
}
