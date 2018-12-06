using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02Controller : MonoBehaviour {

    // Quando viene abilitato, il proiettile resetta
    // la propria velocità. Dato che stiamo utilizzando un pooling
    // di oggetti, una volta riciclato, il proiettile manterrebbe
    // la velocità che aveva quando ha colpito un bersaglio
	void OnEnable ()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.velocity = Vector3.zero;
        }
	}
	
}
