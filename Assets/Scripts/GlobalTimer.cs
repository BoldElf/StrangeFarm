using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{

    private float timer;
   
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text TextSecond;

    [SerializeField] private Player player;
    [SerializeField] private float maxTime;
    [SerializeField] private int maxPlayerCoin;
   

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

        
        if(timer > maxTime)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
            TextSecond.text = StringTime.SecondToTimeString(timer);
        }
        
        if(player.Coin >= maxPlayerCoin)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
            TextSecond.text = StringTime.SecondToTimeString(timer);
        }
    }
}
