using UnityEngine;

/// <summary>
/// Questo componente si preoccupa di controllare il movimento di un proiettile.
/// Estende le capacità di BulletBase.
/// </summary>
public class Bullet03Controller : BulletBase {
    
    // La velocità base del proiettile
    public float speed = 60f;

    public float autoDestroyTimer = 1f;

    protected float countdown;

    public KeyCode activationKey = KeyCode.F;

    public int numGeneratedBullets = 10;

    public ObjectPoolerScriptableObject bulletPooler;

    // Quando il proiettile viene abilitato,
    // resetto il countdown.
    private void OnEnable()
    {
        countdown = autoDestroyTimer;
    }

    // Ad ogni frame muove il proiettile sull'asse z e controlla
    // se il proiettile deve esplodere.
    void Update ()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            float angle = 360 / (float)numGeneratedBullets;

            for (int i = 0; i < numGeneratedBullets; i++)
            {
                GameObject bullet = bulletPooler.GetObject();
                bullet.transform.position = transform.position;
                Quaternion rotation = Quaternion.Euler(0, angle * i, 0);
                bullet.transform.rotation = rotation;
            }
            gameObject.SetActive(false);
        }
	}
}
