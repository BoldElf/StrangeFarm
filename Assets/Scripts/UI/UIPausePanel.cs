using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPausePanel : MonoBehaviour
{
    private const string MainMenuTitle = "MainMenu";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuTitle);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
