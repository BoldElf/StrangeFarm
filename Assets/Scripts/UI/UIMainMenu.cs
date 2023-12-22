using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GlobalTimer[] globalTimer;
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

        for (int i = 1; i <= sceneList.Count; i++)
        {
            Debug.Log(PlayerPrefs.GetFloat(i.ToString(), 100));
        }
        //PlayerPrefs.DeleteAll();

    }

    private int abc = 0;

    public void Continue()
    {
        for(int i = 1; i <= sceneList.Count;i++)
        {
            Debug.Log(PlayerPrefs.GetFloat(i.ToString(), 10000));
            /*
            if (PlayerPrefs.GetFloat(i.ToString(),0) ==0 )
            {
                SceneManager.LoadScene(i);
                return;
            }
            */
            if (PlayerPrefs.GetFloat(i.ToString(),10000) > globalTimer[i-1].MaxTimer && abc == 0)
            {
                /*
                Debug.Log(i);

                SceneManager.LoadScene(i);
                */

                //return;

                //abc += 1;
                abc = i;
            }
        }
        
        SceneManager.LoadScene(abc);
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
