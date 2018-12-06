using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01Controller : MonoBehaviour {

    // La velocità base del proiettile
    public float speed = 60f;
    	
	// Ad ogni frame muove il proiettile sull'asse z
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
