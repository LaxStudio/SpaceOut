using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    [HideInInspector]

    public float startHp = 100;
    private float hp;

    [Header("Unity Stuff")]
    public Image hpBar;

    private void Start()
    {
        target = Waypoints.points[0];
        hp = startHp;
    }

    private void Update()
    {
        if (wavepointIndex <= Waypoints.points.Length - 1)
        {
            // Move to next waypoint
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector2.Distance(transform.position, target.position) < 0.2f)
            {
                GetNextWayPoint();
            }
        }
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            //Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDmg(float amount)
    {
        hp -= amount;
        hpBar.fillAmount = hp / startHp;
    }


}