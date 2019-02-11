using UnityEngine;

/// <summary>
/// Questo componente si occupa di tenere traccia dei punti ferita
/// di un gameobject
/// </summary>
public class Health : MonoBehaviour {

    // Il numero di punti ferita all'inizio della partita
    protected int _startingHitPoints = 10;

    // Il numero di punti ferita
    [SerializeField]
    protected int hitPoints = 10;

    // Il numero di punti ferita
    [SerializeField]
    protected int pointsWhenDestroyed = 10;

    // L'effetto di esplosione
    [SerializeField]
    protected ObjectPoolerScriptableObject explosionFxPooler;

    // L'effetto audio di esplosione
    [SerializeField]
    protected AudioClip explosionSfx;

    // Riferimento allo scriptable object utilizzato per gli
    // eventi interni del gioco
    public GameDataScriptableObject gameData;

    private void Start()
    {
        _startingHitPoints = hitPoints;
        gameData.SetPlayerHealthPercent(1);
    }

    // Questo metodo, permette di aggiungere un danno al gameobject
    // che contiene questo componente
    public void Damage(int damageCaused)
    {
        // Debug.Log("Damage: " + damageCaused);

        // Rimuovo i punti ferita
        hitPoints -= damageCaused;

        // Debug.Log("Remaining hit Points: " + hitPoints);
        int enemiesPlayer = LayerMask.NameToLayer("Enemies");
        // Se il numero di punti ferita sono zero o meno...
        if(hitPoints <= 0 && gameObject.layer == enemiesPlayer)
        {
            // ... aggiungo i punti ai dati di gioco e ...
            gameData.AddPoints(pointsWhenDestroyed);
            // ... distruggo l'oggetto
            Destroy();
        } else
        {
            gameData.SetPlayerHealthPercent((float)hitPoints / (float)_startingHitPoints);
            if(hitPoints <= 0)
            {
                Destroy();
            }
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
        if(explosionFxPooler != null) 
        {
            GameObject explosionFx = explosionFxPooler.GetObject();
            explosionFx.transform.position = transform.position;
        }
        // Disabilito l'oggetto
        gameObject.SetActive(false);
        // resetto i punti ferita
        hitPoints = _startingHitPoints;
    }
}
