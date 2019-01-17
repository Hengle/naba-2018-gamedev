using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShipWars/GameData", fileName = "GameData")]
public class GameDataScriptableObject : ScriptableObject
{
    #region events

    // La lista dei listener degli eventi
    protected List<IGameEventListener> listeners = new List<IGameEventListener>();

    /// <summary>
    /// Per tutti i listener registrati, emette l'evento
    /// </summary>
    public virtual void Raise()
    {
        foreach (IGameEventListener listener in listeners)
        {
            listener.OnEvent();
        }
    }

    /// <summary>
    /// Permette di registrare un listener
    /// </summary>
    public virtual void RegisterListener(IGameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    /// <summary>
    /// Permette di deregistrare un listener
    /// </summary>
    /// <param name="listener">Listener.</param>
    public virtual void UnregisterListener(IGameEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
    #endregion

    #region data

    protected int _points = 0;

    /// <summary>
    /// Aggiunge i punti al totale
    /// </summary>
    public void AddPoints(int val)
    {
        _points += val;
        Raise();
    }

    /// <summary>
    /// Inizializza i punti
    /// </summary>
    public void SetPoints(int val)
    {
        _points = val;
        Raise();
    }

    /// <summary>
    /// Ritorna il valore dei punti guadagnati
    /// </summary>
    /// <returns>The points.</returns>
    public int GetPoints()
    {
        return _points;
    }

    #endregion
}
