using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{
    public Text message;

    private void Start()
    {
        message.text = "Please Select a Level";
    }

    public void LevelButtonOver(string text)
    {
        message.text = text;
    }

    public void LevelButtonClick(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LevelButtonOut()
    {
        message.text = "Please Select a Level";
    }


}
