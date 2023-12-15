using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITradeFish : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject tradeObject;
    [SerializeField] private GameObject noBone;
    [SerializeField] private GameObject noFish;

    private Trade trade;

    private void Start()
    {
        trade = tradeObject.GetComponentInChildren<Trade>();
        trade.playerExit += trade_playerExit;
    }

    private void trade_playerExit()
    {
        noBone.SetActive(false);
        noFish.SetActive(false);
    }

    public void BoneOnBait()
    {
        if(player.Bone >= 1)
        {
            player.MinusBone();
            player.AddFhishingBait();
            Debug.Log(player.Bait);
        }
        else
        {
            gameObject.SetActive(false);
            noBone.SetActive(true);
        }
    }

    public void FishOnWood()
    {
        if(player.Fish >= 1)
        {
            player.MinusFish();
            player.AddWood();
            Debug.Log(player.Wood);
        }
        else
        {
            gameObject.SetActive(false);
            noFish.SetActive(true);
        }
    }

    
}
