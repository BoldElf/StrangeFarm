using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private CatDamager cat;
    public event UnityAction PlayerMinusHealth;

    [SerializeField] private GameObject deathPanel;

    [SerializeField] private AudioSource hitSound;

    private Player player;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();

        if(enemy != null)
        {
            enemy.DamagePlayer += damagePlayer;
        }
        
        if(cat != null)
        {
            cat.CatDamage += damagePlayer;
        }
        
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

            if(hitSound != null)
            {
                hitSound.Play();
            }
        }
        else
        {
            deathPanel.SetActive(true);
        }
        
    }
}
