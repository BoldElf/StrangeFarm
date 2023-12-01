using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    private AudioSource audioClick;

    private void Start()
    {
        audioClick = gameObject.GetComponent<AudioSource>();
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
}
