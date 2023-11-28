using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICatShop : MonoBehaviour
{
    [SerializeField] private Player player;

    public void SellMilk()
    {
        if(player.Milk >= 1)
        {
            player.SellMilk();
        }
    }

}
