using UnityEngine;

/// <summary>
/// Questa classe serve da contenitore dati per le statistiche della
/// navicella del giocatore.
/// </summary>
[CreateAssetMenu(menuName = "ShipWars/ShipData", fileName = "ShipData")]
public class ShipDataScriptableObject : ScriptableObject {

    // La velocità della navicella
    public float speed = 30f;

    // La massima rotazione ottenibile dalla navicella
    public float maxRoll = 45;

}
