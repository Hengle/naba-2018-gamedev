﻿using UnityEngine;

/// <summary>
/// Questo componente si occupa di provocare danno ad un oggetto con il quale
/// collide, nel caso quest'ultimo sia dotato di una Health
/// </summary>
public class DamageOnCollision : MonoBehaviour
{
    public ObjectPoolerScriptableObject explosionPooler;

    // Il numero di punti ferita causati quando l'oggetto collide
    public int damageCaused = 5;

    /// <summary>
    /// Questa callback viene chiamata se l'oggetto (che deve possedere un Collider)
    /// entra in collisione con un altro oggetto contenente un Collider
    /// </summary>
    /// <param name="collision">Collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        // Se è stato definito un effetto per l'esplosione, questo viene instanziato in scena...
        if(explosionPooler != null)
        {
            GameObject explosion = explosionPooler.GetObject();
            // ... e posizionato dove si trova il gameobject contenente questo componente
            explosion.transform.position = transform.position;
        }

        // Recupero il componente Health del gameobject con cui sono entrato in collisione e,...
        Health health = collision.gameObject.GetComponent<Health>();
        // ... se esiste...
        if(health != null)
        {
            // ... gli prvoco danno
            health.Damage(damageCaused);
        }

        // Elimino il proiettile
        Destroy();
    }

    // L'oggetto non viene effettivamente distrutto,
    // ma disabilitato, rendendolo disponibile di nuovo
    // all'object pooler
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}