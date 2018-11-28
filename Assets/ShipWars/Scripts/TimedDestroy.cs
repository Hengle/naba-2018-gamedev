using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{

    public float delay = 1f;

	void Start ()
    {
        Invoke("DestroyObject", delay);	
	}

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
