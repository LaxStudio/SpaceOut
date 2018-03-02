using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform enemyPrefab; // Enemy to spawn
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemy = 0.5f;

    private float counter = 2f;
    private int waveNumber = 1;

    void Update()
    {
        if (counter <= 0f)
        {
            StartCoroutine( SpawnWave() );
            counter = timeBetweenWaves;
        }

        counter -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemy);
        }
        //waveNumber++;
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }


}
