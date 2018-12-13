using UnityEngine;

/// <summary>
/// Componente base dei proiettili. Si preoccupa di 
/// disabilitarli quando non sono più visibili dalle camere in scena.
/// </summary>
[RequireComponent(typeof(Renderer))]
public class BulletBase : MonoBehaviour
{
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
