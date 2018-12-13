using UnityEngine;

/// <summary>
/// Questo componente si preoccupa di controllare il movimento di un proiettile.
/// Estende le capacità di BulletBase.
/// </summary>
public class Bullet02Controller : BulletBase {

    // Quando viene abilitato, il proiettile resetta
    // la propria velocità. Dato che stiamo utilizzando un pooling
    // di oggetti, una volta riciclato, il proiettile manterrebbe
    // la velocità che aveva quando ha colpito un bersaglio
	void OnEnable ()
    {
        // Resetto i valori del rigidbody modificati
        // dalla constant force
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
	}
	
}
