using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    // I punti di gioco
    public Text points;

    // La barra della salute del giocatore
    public Slider healthBar;

    // Riferimento allo scriptable object dei dati di gioco
    public GameDataScriptableObject gameData;

    /// <summary>
    /// Inizializzo i dati
    /// </summary>
    private void Start()
    {
        gameData.SetPoints(0);
        UpdateData();
    }

    /// <summary>
    /// Aggiornamento della UI
    /// </summary>
    public void UpdateData()
    {
        UpdatePoints();
        UpdateHealth();
    }

    /// <summary>
    /// Aggiorno il testo dei punti
    /// </summary>
    public void UpdatePoints()
    {
        points.text = "Points: " + gameData.GetPoints().ToString("0000000");
    }

    /// <summary>
    /// Aggiorno la barra della salute
    /// </summary>
    public void UpdateHealth()
    {
        healthBar.value = gameData.GetPlayerHealthPercent();
    }
}
