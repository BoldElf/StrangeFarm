using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private AudioSource audioS;

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
        Debug.Log(PlayerPrefs.GetFloat("1", 0));
        Debug.Log(PlayerPrefs.GetFloat("2", 0));
    }

    public void Play()
    {
        audioS.Play();
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("1");
        PlayerPrefs.DeleteKey("2");
        SceneManager.LoadScene(1);
        //PlayerPrefs.DeleteAll();
        
    }

    //private int abc = 0;

    public void Continue()
    {
        for(int i = 1; i <= sceneList.Count;i++)
        {
            if (PlayerPrefs.GetFloat(i.ToString(),0) ==0 )
            {
                SceneManager.LoadScene(i);
                return;
            }
        }

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
