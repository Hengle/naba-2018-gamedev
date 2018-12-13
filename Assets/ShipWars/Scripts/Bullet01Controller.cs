using UnityEngine;

/// <summary>
/// Questo componente si preoccupa di controllare il movimento di un proiettile.
/// Estende le capacità di BulletBase.
/// </summary>
public class Bullet01Controller : BulletBase {

    // La velocità base del proiettile
    public float speed = 60f;
    	
	// Ad ogni frame muove il proiettile sull'asse z
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
