using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Questo componente si occupa di tenere traccia dei punti ferita
/// di un gameobject
/// </summary>
public class Health : MonoBehaviour {
    
    // Il numero di punti ferita
    [SerializeField]
    protected int hitPoints = 10;

    // Il numero di punti ferita
    [SerializeField]
    protected int pointsWhenDestroyed = 10;

    // Riferimento allo scriptable object utilizzato per gli
    // eventi interni del gioco
    public GameDataScriptableObject gameData;

    // Questo metodo, permette di aggiungere un danno al gameobject
    // che contiene questo componente
    public void Damage(int damageCaused)
    {
        Debug.Log("Damage: " + damageCaused);

        // Rimuovo i punti ferita
        hitPoints -= damageCaused;

        Debug.Log("Remaining hit Points: " + hitPoints);

        // Se il numero di punti ferita sono zero o meno...
        if(hitPoints <= 0)
        {
            // ... aggiungo i punti ai dati di gioco e ...
            gameData.AddPoints(pointsWhenDestroyed);
            // ... distruggo l'oggetto
            Destroy();
        }
    }

    // L'oggetto non viene effettivamente distrutto,
    // ma disabilitato, rendendolo disponibile di nuovo
    // all'object pooler
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
