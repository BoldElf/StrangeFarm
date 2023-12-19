using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{

    private float timer;
   
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text TextSecond;

    [SerializeField] private Player player;

    [SerializeField] private float EndTime;

    [SerializeField] private float minmumTime;
    public float MinimumTime => minmumTime;


    [SerializeField] private float normTime;
    [SerializeField] private float maxTime;

    [SerializeField] private int maxPlayerCoin;
    public int MaxPlayerCoin => maxPlayerCoin;

    [SerializeField] private string number;

    //[SerializeField] private EndPanelController endPanelController;

    
    

    public event UnityAction MinumTime;
    public event UnityAction NormTime;
    public event UnityAction MaxTime;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        
        if(timer >= EndTime)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
            TextSecond.text = StringTime.SecondToTimeString(timer);

            if(PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 100) > timer && minmumTime >= timer)
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), timer);
            }
            
        }

        if(timer <= minmumTime)
        {
            MinumTime?.Invoke();
        }
        if (timer > minmumTime && timer <= normTime) //timer >= normTime
        {
            NormTime?.Invoke();
        }
        if (timer > normTime && timer <= maxTime)
        {
            MaxTime?.Invoke();
        }


        if (player.Coin >= maxPlayerCoin)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
            TextSecond.text = StringTime.SecondToTimeString(timer);
            if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 100) > timer)
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), timer);
            }
        }
    }
}
