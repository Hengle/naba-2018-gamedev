using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public ObjectPoolerScriptableObject enemyPooler;

    public float minSpawnTime = 2f;
    public float maxSpawnTime = 10f;

    public bool active = true;

    public Collider spawnBox;

    private void Start()
    {
        StartCoroutine("Spawn");
        spawnBox.isTrigger = true;
    }

    protected IEnumerator Spawn()
    {
        while(active)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            GameObject enemyGo = enemyPooler.GetObject();
            float min = spawnBox.bounds.min.x;
            float max = spawnBox.bounds.max.x;
            float posX = transform.position.x + Random.Range(min, max);
            enemyGo.transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
    }
}
