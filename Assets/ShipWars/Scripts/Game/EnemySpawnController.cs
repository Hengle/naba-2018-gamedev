using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    // Il pooler da cui recuperare le istanze dei nemici
    public ObjectPoolerScriptableObject enemyPooler;

    // Valori con cui generare i tempi di spawn casuali
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 10f;

    // Indica se 
    public bool active = true;

    // Questo collider, se presente, viene utilizzato come zona di spawn
    public Collider spawnBox;

    private void Start()
    {
        spawnBox.isTrigger = true;
        if (active) StartSpawning();
    }

    public void StartSpawning()
    {
        active = true;
        StartCoroutine("Spawn");
    }

    public void StopSpawning()
    {
        active = false;
    }

    /// <summary>
    /// Questa coroutine genera ad intervalli regolari un nemico
    /// </summary>
    protected IEnumerator Spawn()
    {
        while(active)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            GameObject enemyGo = enemyPooler.GetObject();
            float posX = transform.position.x;
            if(spawnBox != null)
            {
                float min = spawnBox.bounds.min.x;
                float max = spawnBox.bounds.max.x;
                posX = transform.position.x + Random.Range(min, max);
            }
            enemyGo.transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
    }
}
