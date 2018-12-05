using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShipWars/ObjectPooler", fileName ="ObjectPooler")]
public class ObjectPoolerScriptableObject : ScriptableObject
{
    public GameObject poolablePrefab;

    List<GameObject> _list = new List<GameObject>();

    public GameObject GetObject()
    {
        foreach(GameObject go in _list)
        {
            if(go != null && !go.activeInHierarchy)
            {
                go.SetActive(true);
                return go;
            }
        }
        GameObject newGo = Instantiate(poolablePrefab);
        _list.Add(newGo);
        return newGo;
    }

}
