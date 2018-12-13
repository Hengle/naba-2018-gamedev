using UnityEngine;

/// <summary>
/// Questo componente si preoccupa di far ruotare un oggetto lungo l'asse y.
/// Viene utilizzato in particolare sulle torrette delle navicelle.
/// </summary>
public class AutoRotator : MonoBehaviour {

    // La velocità di rotazione
    public float speed = 10f;

	void Update ()
    {
        transform.Rotate(Vector3.up, speed);	
	}
}
