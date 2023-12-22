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

    [SerializeField] private Text textSecond;

    [SerializeField] private Player player;

    [SerializeField] private float EndTime;

    [SerializeField] private float minmumTime;
    public float MinimumTime => minmumTime;


    [SerializeField] private float normTime;
    [SerializeField] private float maxTime;
    public float MaxTimer => maxTime;

    [SerializeField] private int maxPlayerCoin;
    public int MaxPlayerCoin => maxPlayerCoin;

    public event UnityAction MinumTime;
    public event UnityAction NormTime;
    public event UnityAction MaxTime;

    public event UnityAction endCoin;


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
            textSecond.text = StringTime.SecondToTimeString(timer);

            if(PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 100) > timer && maxTime >= timer)
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

            endCoin?.Invoke();
            /*
            endPanel.SetActive(true);
            Time.timeScale = 0;
            TextSecond.text = StringTime.SecondToTimeString(timer);
            if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 100) > timer)
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), timer);
            }
            */
        }
    }

    public void setActiveText()
    {
        endPanel.SetActive(true);
        textSecond.text = StringTime.SecondToTimeString(timer);

        if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 0) == 0)
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), timer);
        }
        else
        {
            if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 0) < timer)
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), timer);
            }
        }
            
        /*
        if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 0) < timer)
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), timer);
        }
        */
        Time.timeScale = 0;
    }
}
