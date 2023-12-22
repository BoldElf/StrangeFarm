using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITradeFish : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject tradeObject;
    [SerializeField] private GameObject noBone;
    [SerializeField] private GameObject noFish;

    [SerializeField] private GameObject third;

    [SerializeField] private int costOfScissors;

    [SerializeField] private GameObject noCoinUI;

    private Trade trade;

    private void Start()
    {
        trade = tradeObject.GetComponentInChildren<Trade>();
        //trade.playerExit += trade_playerExit;
    }

    /*
    private void trade_playerExit()
    {
        if(noBone != null)
        {
            noBone.SetActive(false);
        }
        if(noFish != null)
        {
            noFish.SetActive(false);
        }
        
    }
    */

    public void BoneOnBait()
    {
        if(player.Bone >= 1)
        {
            player.MinusBone();
            player.AddFhishingBait();
        }
        else
        {
            gameObject.SetActive(false);
            noBone.SetActive(true);
        }
    }

    public void FishOnCoin()
    {
        if(player.Fish >= 1)
        {
            player.MinusFish();
            player.AddCoin(10);
        }
        else
        {
            gameObject.SetActive(false);
            noFish.SetActive(true);
        }
    }

    public void BuyScissors()
    {
        if(player.Coin >= costOfScissors)
        {
            if(player.Scissors == false)
            {
                player.AddScissors();
                player.AddCoin(-costOfScissors);
            }
            if(player.Scissors == true)
            {
                third.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
            noCoinUI.SetActive(true);
        }
       
        
    }



}
