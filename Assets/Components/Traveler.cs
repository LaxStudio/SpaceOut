using UnityEngine;

public class Traveler : MonoBehaviour
{
    public FloatReference speed;
    public FloatReference travelDistance;
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
        if (dir == null || (distance >= travelDistance))
        {
            Destroy(gameObject);
            return;
        }
        
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    public void SetDirectionWithTarget(Vector3 target)
    {
        dir = target - transform.position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

}
