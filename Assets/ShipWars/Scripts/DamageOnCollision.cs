using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public GameObject explosionPrefab;

    public int damageCaused = 5;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if(explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = transform.position;
        }

        Health health = collision.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.Damage(damageCaused);
        }

        Destroy(gameObject);
    }
}
