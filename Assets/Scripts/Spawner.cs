using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawnPoints;
    public List<int> waveElementCounts;

    [Range(0.1f,5)]public float spawnInterval = 1f;
    [Range(0,10)]public float waveInterval = 10f;

    public int enemiesLeft;

    public UnityEvent onWaweStart;
    public UnityEvent onWaweEnded;

    public void Spawn()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    async void Start()
    {
        Random.seed = 5;

        foreach (var count in waveElementCounts)
        {
            onWaweStart.Invoke();
            enemiesLeft = count;

            while (enemiesLeft > 0)
            {
               await new WaitForSeconds(spawnInterval);
               Spawn();
               enemiesLeft--;
            }
            onWaweEnded.Invoke();
            await new WaitForSeconds(waveInterval);

        }
    }
}
