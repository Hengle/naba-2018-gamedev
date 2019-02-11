using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{

    // L'oggetto contenente i dati di configurazione della navetta
    public EnemyShipDataScriptableObject data;

    // Le liste di elementi che saranno le bocche di fuoco
    public Transform[] weaponGunList;

    // I countdown per tenere conto dell'intervallo di tempo tra un proiettile sparato ed il successivo
    protected float _weaponCountdown;

    // Inizializzazione dei dati
    void Start()
    {
        // Controlla che la velocità della navicella non sia
        // negativa (i comandi sarebbero rivesciati)
        if (data.speed < 0.1f)
        {
            data.speed = 0.1f;
        }
    }

    /// <summary>
    /// Callback eseguita una volta a frame.
    /// Aggiorna il sistema di movimento e quello di fuoco.
    /// </summary>
    private void Update()
    {
        UpdateFirerateCountdown();
        UpdateMovement();
        UpdateWeapons();
    }

    /// <summary>
    /// Calcola il tempo rimanente prima che il prossimo
    /// proiettile possa essere sparato.
    /// </summary>
    void UpdateFirerateCountdown()
    {
        _weaponCountdown -= Time.deltaTime;
    }

    /// <summary>
    /// Aggiornamento del sistema di fuoco
    /// </summary>
    void UpdateWeapons()
    {
        // Sistema di armi
        // Controllo la situazione di auto-fire
        if (_weaponCountdown <= 0)
        {
            ShootWeapon(weaponGunList, data.bulletObjectPooler, data.weaponSfx);

            // Se ho sparato, reinizializzo il countdown
            _weaponCountdown = Random.Range(data.minWeaponFireInterval, data.maxWeaponFireInterval);
        }
    }

    void ShootWeapon(Transform[] list, ObjectPoolerScriptableObject objectPooler, AudioClip sfx = null)
    {
        if (sfx != null)
        {
            SoundManager.Instance.PlaySound(sfx, list[0].position);
        }
        // Per ogni bocca di fuoco...
        foreach (Transform gunTransform in list)
        {
            // ... richiedo all'object pooler corrispondente un proiettile e...
            GameObject bullet = objectPooler.GetObject();
            // ... lo posiziono sulla bocca di fuoco
            bullet.transform.position = gunTransform.position;
            Quaternion rotation = Quaternion.Euler(0, gunTransform.rotation.eulerAngles.y, 0);
            bullet.transform.rotation = rotation;
        }
    }

    // L'oggetto si muove lungo l'asse x seguendo una curva
    void UpdateMovement()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        float posX = data.movementCurve.Evaluate(pos.y);
        transform.Translate(posX * .1f, 0, data.speed * Time.deltaTime);
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