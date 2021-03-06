﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShipWars/ObjectPooler", fileName ="ObjectPooler")]
public class ObjectPoolerScriptableObject : ScriptableObject
{
    // I prefab da cui creare i poolable objects
    public GameObject[] poolablePrefabs;

    // La lista dove immagazzinare e recuperare gli oggetti che
    // saranno soggetti al pooling
    List<GameObject> _list = new List<GameObject>();

    /// <summary>
    /// Ritorna un oggetto dalla lista del pooling
    /// </summary>
    public GameObject GetObject()
    {
        // Cerco nella lista un oggetto "disponibile", cioè che sia stato
        // precedentemente disabilitato
        foreach(GameObject go in _list)
        {
            // Se lo trovo...
            if(go != null && !go.activeInHierarchy)
            {
                // ... lo abilito e lo ritorno, ...
                go.SetActive(true);
                return go;
            }
        }
        // ... altrimenti ne creo uno nuovo, ...
        GameObject prefab = poolablePrefabs[Random.Range(0, poolablePrefabs.Length)];
        GameObject newGo = Instantiate(prefab);
        // ... lo aggiungo alla lista ...
        _list.Add(newGo);
        // ... e lo ritorno
        return newGo;
    }

}
