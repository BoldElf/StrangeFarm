using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoin : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text text;

    /*
    private void Update()
    {
        text.text = player.Coin.ToString();
    }
    */

    private void Start()
    {
        text.text = player.Coin.ToString();
        player.Trade += UpdateCoin;
    }

    private void UpdateCoin()
    {
        text.text = player.Coin.ToString();
    }
}
