using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{
    [Header("Main Settings")]

    public Text message;

    [Header("Audio Settings")]

    public AudioClip buttonOverSfx;
    public AudioClip buttonClickSfx;


    private void Start()
    {
        message.text = "Please Select a Level";
    }

    /// <summary>
    /// Sul rollover di un pulsante, visualizza il messaggio corrispondente
    /// </summary>
    public void LevelButtonOver(string text)
    {
        message.text = text;
        if (buttonOverSfx != null) SoundManager.Instance.PlaySound(buttonOverSfx, transform.position);
    }

    /// <summary>
    /// Sul click del pulsante, carica il livello corrispondente
    /// </summary>
    public void LevelButtonClick(string levelName)
    {
        SceneManager.LoadScene(levelName);
        if (buttonOverSfx != null) SoundManager.Instance.PlaySound(buttonClickSfx, transform.position);
    }

    /// <summary>
    /// Sul rollout di un pulsante, resetta il messaggio
    /// </summary>
    public void LevelButtonOut()
    {
        message.text = "Please Select a Level";
    }


}
