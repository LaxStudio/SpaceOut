using UnityEngine;
using UnityEngine.UI;

public class EnemyMover : MonoBehaviour
{

    public float speed = 5f;


    // For Waypoints
    private Transform target;
    private int wavepointIndex = 0;

    //Random movement
    private float changeTime;
    private readonly float dirChangeTime = 3f;
    private Vector2 movementDir;
    private Vector2 movementPerSecond;

    private void Start()
    {
        target = Waypoints.points[0];

        changeTime = 0f;
        newMovementVector();
    }

    private void Update()
    {
        if (wavepointIndex < Waypoints.points.Length)
        {
            // Move to next waypoint
            Vector2 dir = target.position - transform.position;

            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector2.Distance(transform.position, target.position) < 0.2f)
            {
                GetNextWayPoint();
            }
        }
        else
        {
            if (Time.time - changeTime > dirChangeTime)
            {
                changeTime = Time.time;
                newMovementVector();
            }
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
        }
    }

    void newMovementVector()
    {
        movementDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDir * speed;
    }

    void GetNextWayPoint()
    {
        wavepointIndex++;
        if (wavepointIndex < Waypoints.points.Length)
        {     
            target = Waypoints.points[wavepointIndex];
            //Destroy(gameObject);
            //return;
        }

        
    }

}