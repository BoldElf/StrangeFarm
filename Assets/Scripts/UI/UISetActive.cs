using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetActive : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;

    [SerializeField] private Trade[] trade;


    private void Start()
    {
        for (int i = 0; i < trade.Length; i++)
        {
            trade[i].playerExit += Trade_playerExit;
        }
            
    }

    private void Trade_playerExit()
    {
        for(int i = 0; i < buttons.Length;i++)
        {
            buttons[i].SetActive(false);
        }
    }
}
