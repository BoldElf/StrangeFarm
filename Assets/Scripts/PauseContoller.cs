using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseContoller : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    private void Update()
    {
        if (pause.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                Time.timeScale = 0;
                pause.SetActive(true);
            
                return;
            }
        }
        if (pause.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                Time.timeScale = 1;
                pause.SetActive(false);
            }
        }
    }
    
}
