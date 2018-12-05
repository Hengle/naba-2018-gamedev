using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02Controller : MonoBehaviour {

	void OnEnable ()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.velocity = Vector3.zero;
        }
	}
	
}
