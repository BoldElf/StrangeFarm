using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITradeShop : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject bowlZero;
    [SerializeField] private GameObject coinZero;

    public void BuySeed()
    {
        if (player.Coin >= 20)
        {
            player.TradeSeed();
        }
        else
        {
            gameObject.SetActive(false);
            coinZero.SetActive(true);
        }
    }

    public void SellBowl()
    {
        if (player.Bowl >= 1)
        {
            player.SellBowl();
        }
        else
        {
            gameObject.SetActive(false);
            bowlZero.SetActive(true);
        }
    }
}
