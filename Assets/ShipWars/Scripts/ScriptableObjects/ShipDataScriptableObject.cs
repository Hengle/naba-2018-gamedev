﻿using UnityEngine;

/// <summary>
/// Questa classe serve da contenitore dati per le statistiche della
/// navicella del giocatore.
/// </summary>
[CreateAssetMenu(menuName = "ShipWars/ShipData", fileName = "ShipData")]
public class ShipDataScriptableObject : ScriptableObject
{

    [Header("Movement")]

    // La velocità della navicella
    [Tooltip("Ship speed multiplied by framerate deltaTime")]
    public float speed = 30f;

    // La massima rotazione ottenibile dalla navicella
    [Tooltip("Maximum rotation during movement")]
    public float maxRoll = 45;

    [Space]

    [Header("Weapon System 1")]

    // L'object pooler del primo proiettile
    public ObjectPoolerScriptableObject bullet1ObjectPooler;

    // Indica se il primo proiettile debba essere sparato in autofire oppure no
    public bool weapon1Autofire;

    // Il pulsante da tastiera per sparare la prima arma
    public KeyCode weapon1Key;

    // Indica il tempo che deve passare tra un proiettile sparato e quello successivo
    public float weapon1FireInterval;

    public AudioClip weapon1Sfx;

    [Space]

    [Header("Weapon System 2")]

    // L'object pooler del secondo proiettile
    public ObjectPoolerScriptableObject bullet2ObjectPooler;

    // Indica se il secondo proiettile debba essere sparato in autofire oppure no
    public bool weapon2Autofire;

    // Il pulsante da tastiera per sparare la seconda arma
    public KeyCode weapon2Key;

    // Indica il tempo che deve passare tra un proiettile sparato e quello successivo
    public float weapon2FireInterval;

    public AudioClip weapon2Sfx;

}
