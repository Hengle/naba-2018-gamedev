using UnityEngine;

/// <summary>
/// Questa classe serve da contenitore dati per le statistiche della
/// navicella del giocatore.
/// </summary>
[CreateAssetMenu(menuName = "ShipWars/ShipData", fileName = "ShipData")]
public class ShipDataScriptableObject : ScriptableObject {

    [Header("Movement")]

    // La velocità della navicella
    [Tooltip("Ship speed multiplied by framerate deltaTime")]
    public float speed = 30f;

    // La massima rotazione ottenibile dalla navicella
    [Tooltip("Maximum rotation during movement")]
    public float maxRoll = 45;

    [Space]

    [Header("Weapon System 1")]

    // Il gameobject generato quando si spara la prima arma
    public GameObject bullet1Prefab;

    // Il pulsante da tastiera per sparare la prima arma
    public KeyCode weapon1Key;

    [Space]

    [Header("Weapon System 2")]

    // Il gameobject generato quando si spara la seconda arma
    public GameObject bullet2Prefab;

    // Il pulsante da tastiera per sparare la seconda arma
    public KeyCode weapon2Key;
}
