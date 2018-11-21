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

    public GameObject bullet1Prefab;

    public KeyCode weapon1Key;
}
