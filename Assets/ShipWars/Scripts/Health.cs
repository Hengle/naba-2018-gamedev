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
            // ... distruggo l'oggetto
            Destroy();
        }
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
