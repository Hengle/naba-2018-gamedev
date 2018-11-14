using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public ShipDataScriptableObject data;

	// Use this for initialization
	void Start () {
		if (data.speed < 0.1f)
        {
            data.speed = 0.1f;
        }

    }

    // Update is called once per frame
    void Update() {
        float vMove = Input.GetAxis("Vertical");
        float hMove = Input.GetAxis("Horizontal");

        vMove *= data.speed;
        hMove *= data.speed;

        vMove *= Time.deltaTime;
        hMove *= Time.deltaTime;

        Vector3 nextPosition = new Vector3(
            transform.position.x + hMove,
            transform.position.y,
            transform.position.z + vMove);

        Vector3 viewPosition = Camera.main.WorldToViewportPoint(nextPosition);

        if(viewPosition.x > 0.1f &&
            viewPosition.x < 0.9f &&
            viewPosition.y > 0.1f &&
            viewPosition.y < 0.9f)
        {
            transform.position = nextPosition;
        }

        float roll = Input.GetAxis("Horizontal");

        roll *= -data.maxRoll;

        Quaternion nextRotation = Quaternion.Euler(0, 0, roll);
        transform.rotation = nextRotation;
    }
}
