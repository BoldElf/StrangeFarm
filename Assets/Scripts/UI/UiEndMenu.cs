using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiEndMenu : MonoBehaviour
{
    [SerializeField] private GameObject buttonContinue;
    [SerializeField] private EndPanelController endPanelController;
    List<string> sceneList = new List<string>();

    private void Start()
    {
        for (int i = 1; true; i++)
        {
            var s = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
            if (s.Length <= 0)
            {
                break;
            }
            else
            {
                sceneList.Add(s);
            }
        }

        endPanelController.buttonOn += buttonSetActive;
    }

    private void OnDestroy()
    {
        endPanelController.buttonOn -= buttonSetActive;
    }

    private void buttonSetActive()
    {
        buttonContinue.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Next()
    {
        if(sceneList.Count >= SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void InMenu()
    {
        SceneManager.LoadScene(0);
    }
}
