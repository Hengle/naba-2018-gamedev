using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01Controller : MonoBehaviour {

    public float speed = 60f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
