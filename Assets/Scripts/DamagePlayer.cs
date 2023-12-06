using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public event UnityAction PlayerMinusHealth;

    [SerializeField] private GameObject deathPanel;

    private Player player;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        enemy.DamagePlayer += damagePlayer;
    }

    private void Update()
    {
        if(player.PlayerHealth == 0)
        {
            deathPanel.SetActive(true);
        }
    }

    private void damagePlayer()
    {
        if(player.PlayerHealth >= 1)
        {
            PlayerMinusHealth?.Invoke();
        }
        else
        {
            deathPanel.SetActive(true);
        }
        
    }
}
