using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITradeShop : MonoBehaviour
{
    [SerializeField] private Player player;

    public void BuySeed()
    {
        if (player.Coin >= 20)
        {
            player.TradeSeed();
        }
    }

    public void SellBowl()
    {
        if (player.Bowl >= 1)
        {
            player.SellBowl();
        }
    }
}
