using UnityEngine;

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

    public ObjectPoolerScriptableObject bullet1ObjectPooler;

    // Il pulsante da tastiera per sparare la prima arma
    public KeyCode weapon1Key;

    [Space]

    [Header("Weapon System 2")]

    public ObjectPoolerScriptableObject bullet2ObjectPooler;

    // Il pulsante da tastiera per sparare la seconda arma
    public KeyCode weapon2Key;
}
