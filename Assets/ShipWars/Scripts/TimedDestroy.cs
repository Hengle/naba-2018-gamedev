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
    /// All'Enable del gameobject...
    /// </summary>
	void OnEnable ()
    {
        // ... invoco la sua distruzione, dopo un ritardo
        Invoke("Destroy", delay);	
	}

    // Distruggo l'oggetto
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
