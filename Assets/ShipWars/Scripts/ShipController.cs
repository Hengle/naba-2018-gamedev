using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Questo componente si occupa di controllare le varie funzioni della
/// navetta (movimento, fuoco, motori, etc.)
/// </summary>
public class ShipController : MonoBehaviour {

    public ShipDataScriptableObject data;

    public Transform[] weapon1GunList;
    public Transform[] weapon2GunList;

    // Inizializzazione dei dati
    void Start() {
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
        UpdateMovement();
        UpdateWeapons();
    }

    /// <summary>
    /// Aggiornamento del sistema di fuoco
    /// </summary>
    void UpdateWeapons()
    {
        // Primo sistema di armi
        if(Input.GetKeyDown(data.weapon1Key))
        {
            ShootWeapon(weapon1GunList, data.bullet1ObjectPooler);
        }

        // Secondo sistema di armi
        if (Input.GetKeyDown(data.weapon2Key))
        {
            ShootWeapon(weapon2GunList, data.bullet2ObjectPooler);
        }
    }

    void ShootWeapon(Transform[] list, ObjectPoolerScriptableObject objectPooler)
    {
        foreach(Transform gunTransform in list)
        {
            GameObject bullet = objectPooler.GetObject();
            bullet.transform.position = gunTransform.position;
        }
    }

    /// <summary>
    /// Aggiornamento del sistema di movimento
    /// </summary>
    void UpdateMovement() {
        // Inizializzo il movimento verticale ed orizzontale
        // recuperando le informazioni del thumbstick
        // (che hanno un valore compreso tra -1 ed 1)
        float vMove = Input.GetAxis("Vertical");
        float hMove = Input.GetAxis("Horizontal");

        // Moltiplico al valore precedente la velocità,
        // recuperata dallo scriptableobject 'data'
        vMove *= data.speed;
        hMove *= data.speed;

        // Moltiplico il valore ottenuto sopra per il
        // tempo intercorso dall'ultimo frame (deltaTime)
        // in modo tale che il movimento finale risulti,
        // con un'ottima approssimazione, indipendente dal framerate
        vMove *= Time.deltaTime;
        hMove *= Time.deltaTime;

        // Calcolo la prossima posizione della navicella,
        // aggiungendo alla posizione attuale lo spostamento
        // calcolato precedentemente
        Vector3 nextPosition = new Vector3(
            transform.position.x + hMove,
            transform.position.y,
            transform.position.z + vMove);

        // Trasformo le coordinate trovate rispetto alla viewport
        // della camera. I valori sono compresi da 0,0 (in basso a sinistra)
        // e (1, 1) in alto a destra
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(nextPosition);

        // Se mi trovo all'interno della vista della camera, sposto
        // la posizione del gameobject
        if(viewPosition.x > 0.1f &&
            viewPosition.x < 0.9f &&
            viewPosition.y > 0.1f &&
            viewPosition.y < 0.9f)
        {
            transform.position = nextPosition;
        }

        // Calcolo l'inclinazione della navicella
        // basandomi sul valore della posizione orizzontale
        // del joystick
        float roll = Input.GetAxis("Horizontal");

        // Moltiplico il valore trovato (-1, 1) per la massima
        // inclinazione ottenibile, recuperata dallo scriptable object
        roll *= -data.maxRoll;

        // Calcolo la rotazione, trasformandola in Quaternion
        Quaternion nextRotation = Quaternion.Euler(0, 0, roll);

        // Applico la rotazione al transform del game object
        transform.rotation = nextRotation;
    }
}
