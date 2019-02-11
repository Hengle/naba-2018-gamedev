using UnityEngine;

/// <summary>
/// Questa classe serve da contenitore dati per le statistiche della
/// navicella del giocatore.
/// </summary>
[CreateAssetMenu(menuName = "ShipWars/EnemyShipData", fileName = "EnemyShipData")]
public class EnemyShipDataScriptableObject : ScriptableObject
{

    [Header("Movement")]

    // La velocità della navicella
    [Tooltip("Ship speed multiplied by framerate deltaTime")]
    public float speed = 30f;

    // Il movimento orizzontale
    [Tooltip("Ship horizontal movement curve")]
    public AnimationCurve movementCurve;

    [Space]

    [Header("Weapon System 1")]

    // L'object pooler del primo proiettile
    public ObjectPoolerScriptableObject bulletObjectPooler;

    // Indica il tempo che deve passare tra un proiettile sparato e quello successivo
    public float minWeaponFireInterval = 1;

    public float maxWeaponFireInterval = 2;

    public AudioClip weaponSfx;

}
