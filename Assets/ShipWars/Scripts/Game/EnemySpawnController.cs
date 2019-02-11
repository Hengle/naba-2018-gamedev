using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    // Il pooler da cui recuperare le istanze dei nemici
    public ObjectPoolerScriptableObject enemyPooler;

    // Valori con cui generare i tempi di spawn casuali
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 10f;

    // Indica se lo spawner è attivo (e quindi genera oggetti)
    public bool active = true;

    // Questo collider, se presente, viene utilizzato come zona di spawn
    public Collider spawnBox;

    private void Start()
    {
        spawnBox.isTrigger = true;
        if (active) StartSpawning();
    }

    // Comincia a generare gli oggetti
    public void StartSpawning()
    {
        active = true;
        StartCoroutine("Spawn");
    }

    // Ferma la generazione degli oggetti
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
            // Aspetto un periodo calcolato a caso
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            // Recupero dal pooler l'oggetto generato
            GameObject enemyGo = enemyPooler.GetObject();
            float posX = transform.position.x;

            // Dal collider (spawnBox) recupero un punto a caso, che sarà
            // la posizione di generazione dell'oggetto
            if(spawnBox != null)
            {
                float min = spawnBox.bounds.min.x;
                float max = spawnBox.bounds.max.x;
                posX = transform.position.x + Random.Range(min, max);
            }
            enemyGo.transform.position = new Vector3(posX, transform.position.y, transform.position.z);
            Quaternion rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            enemyGo.transform.rotation = rotation;
        }
    }
}
