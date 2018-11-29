using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Questo componente distrugge il gameobject che lo contiene dopo
/// un numero di secondi. Il conteggio comincia quando il gameobject viene
/// instanziato
/// </summary>
public class TimedDestroy : MonoBehaviour
{

    // Il numero di secondi dopo il quale l'oggetto deve essere distrutto
    public float delay = 1f;

    /// <summary>
    /// Allo Start del gameobject...
    /// </summary>
	void Start ()
    {
        // ... invoco la sua distruzione, dopo un ritardo
        Invoke("DestroyObject", delay);	
	}

    // Distruggo l'oggetto
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
