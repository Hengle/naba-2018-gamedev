using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{

    [Header("Main Settings")]
    public Rigidbody meteorRb;

    public float minSpeed = 10f;
    public float maxSpeed = 30f;
    public float minRotationSpeed = 0;
    public float maxRotationSpeed = 25f;
    public float minScale = .5f;
    public float maxScale = 2f;

	// Use this for initialization
	void Start ()
    {
        meteorRb.AddTorque(Random.Range(minRotationSpeed, maxRotationSpeed), Random.Range(minRotationSpeed, maxRotationSpeed), Random.Range(minRotationSpeed, maxRotationSpeed));
	}

    private void OnEnable()
    {
        transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
    }

    void Update()
    {
        transform.Translate(0, 0, Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
    }

    /// <summary>
    /// Quando non viene più ripreso da una camera...
    /// </summary>
    private void OnBecameInvisible()
    {
        // ... disabilita l'oggetto per renderlo di nuovo
        // disponibile all'object pooler
        gameObject.SetActive(false);
    }

}
