using UnityEngine;

public class EnemyAdder : MonoBehaviour
{
    public EnemySet RuntimeSet;

    private void OnEnable()
    {
        RuntimeSet.Add(this);
    }

    private void OnDisable()
    {
        RuntimeSet.Remove(this);
    }
}
