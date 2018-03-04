using UnityEngine;

public class Traveler : MonoBehaviour
{
    public FloatReference Speed;
    public FloatReference TravelDistance;
    private Vector2 dir;
    private Vector3 start;

    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        var distance = Vector3.Distance(transform.position, start);
        if (dir == null || (distance >= TravelDistance))
        {
            Destroy(gameObject);
            return;
        }
        
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);
    }

    public void SetDirectionWithTarget(Vector3 target)
    {
        dir = target - transform.position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    public void Set(float speed, float travelDistance)
    {
        Speed.UseConstant = true;
        Speed.ConstantValue = speed;
        TravelDistance.UseConstant = true;
        TravelDistance.ConstantValue = travelDistance;

    }
}
