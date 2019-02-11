using UnityEngine;

/// <summary>
/// Questo componente si occupa di provocare danno ad un oggetto con il quale
/// collide, nel caso quest'ultimo sia dotato di una Health
/// </summary>
public class DamageOnCollision : MonoBehaviour
{
    // Il numero di punti ferita causati quando l'oggetto collide
    public int damageCaused = 5;

    // Definisce se l'oggetto deve essere distrutto quando colpisce un bersaglio
    public bool destroyOnHit = true;

    // L'effetto di esplosione
    [SerializeField]
    protected ObjectPoolerScriptableObject explosionFxPooler;

    // L'effetto audio di esplosione
    [SerializeField]
    protected AudioClip explosionSfx;

    /// <summary>
    /// Questa callback viene chiamata se l'oggetto (che deve possedere un Collider)
    /// entra in collisione con un altro oggetto contenente un Collider
    /// </summary>
    /// <param name="collision">Collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        // Recupero il componente Health del gameobject con cui sono entrato in collisione e,...
        Health health = collision.gameObject.GetComponent<Health>();
        // ... se esiste...
        if(health != null)
        {
            // ... gli prvoco danno
            health.Damage(damageCaused);
        }

        if(destroyOnHit)
        {
            // Elimino il proiettile
            Destroy();
        }
    }

    // L'oggetto non viene effettivamente distrutto,
    // ma disabilitato, rendendolo disponibile di nuovo
    // all'object pooler
    void Destroy()
    {
        // Emette l'effetto audio, se disponibile
        if (explosionSfx != null) SoundManager.Instance.PlaySound(explosionSfx, transform.position);

        // Aggiunge l'esplosione, se disponibile
        if (explosionFxPooler != null)
        {
            GameObject explosionFx = explosionFxPooler.GetObject();
            explosionFx.transform.position = transform.position;
        }
        gameObject.SetActive(false);
    }
}
