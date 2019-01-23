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

    public void LevelButtonOver(string text)
    {
        message.text = text;
        if (buttonOverSfx != null) SoundManager.Instance.PlaySound(buttonOverSfx, transform.position);
    }

    public void LevelButtonClick(string levelName)
    {
        SceneManager.LoadScene(levelName);
        if (buttonOverSfx != null) SoundManager.Instance.PlaySound(buttonClickSfx, transform.position);
    }

    public void LevelButtonOut()
    {
        message.text = "Please Select a Level";
    }


}
