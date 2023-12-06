using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private AudioSource audioS;

    public void Play()
    {
        audioS.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        gameObject.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
