using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    // Lo scripatble object utilizzato per la gestione degli eventi
    // interni al gioco
    public GameDataScriptableObject gameData;

    /// <summary>
    /// Le azioni da effettuare in risposta alla ricezione dell'evento
    /// </summary>
    public UnityEvent response;

    /// <summary>
    /// Quando il componente viene abilitato mi registro come listener
    /// </summary>
    protected virtual void OnEnable()
    {
        gameData.RegisterListener(this);
    }

    /// <summary>
    /// Quando il componente viene disabilitato cancello la mia registrazione
    /// </summary>
    protected virtual void OnDisable()
    {
        gameData.UnregisterListener(this);
    }

    /// <summary>
    /// Quando arriva l'evento, procedo ad invocare le azioni da eseguire
    /// </summary>
    public virtual void OnEvent()
    {
        response.Invoke();
    }

}
