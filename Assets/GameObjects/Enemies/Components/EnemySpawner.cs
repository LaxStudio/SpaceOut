using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    //
    // Input values for each wave
    //
    public Wave[] waves;

    //
    // Time between each wave
    //
    public float timeBetweenWaves = 5f;

    private float tic = 2f;
    private int waveNumber = 0;

    void Update()
    {
        if (tic <= 0f)
        {
            StartCoroutine(SpawnWave());
            tic = timeBetweenWaves;
        }

        tic -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.amount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;

        if (waveNumber == waves.Length)
        {
            Debug.Log("LEVEL WON");
            enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}