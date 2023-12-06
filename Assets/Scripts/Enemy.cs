using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private Player player;
    private PlayerContoller playerController;
    private SpriteRenderer sprite_charector;
    private bool playerInCollider = false;

    [SerializeField]private GameObject prefab;

    [SerializeField] private int enemyHealth;
    public int EnemyHealth => enemyHealth;

    public event UnityAction DamagePlayer;
    public event UnityAction <bool> ActivePanel;
    public event UnityAction<bool> BattlePanel;
    public event UnityAction<bool> EnemyLose;
    public event UnityAction<bool> PlayerHit;
    public event UnityAction<bool> EndPanel;

    public event UnityAction EnemyDamage;
    public event UnityAction EnemyHitSound;

    private GameObject swap;

    private int enemyChoice;

    private bool exit = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();
        playerController = collision.transform.GetComponent<PlayerContoller>();
        sprite_charector = collision.transform.GetComponentInChildren<SpriteRenderer>();

        if (player != null && playerController != null)
        {
            playerInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();

        if (player != null)
        {
            playerInCollider = false;
            exit = true;
        }
    }

    private void Update()
    {
        if (playerInCollider == true && exit== true)
        {
            exit = false;

            if(sprite_charector != null)
            {
                sprite_charector.enabled = false;
                swap = Instantiate(prefab, player.transform);
            }

            playerController.enabled = false;

            BattlePanel?.Invoke(true);
        }

        if(enemyHealth == 0)
        {
            EnemyDeath();
        }
    }

    public void StoneInvoke()
    {
        EnemyFight(0);
    }
    public void KnightInvoke()
    {
        EnemyFight(1);
    }

    public void DodgeInvoke()
    {
        EnemyFight(2);
    }

    private void EnemyFight(int charecterChoice)
    {
        enemyChoice = UnityEngine.Random.Range(0, 3);

        if (enemyChoice == charecterChoice)
        {
            while(enemyChoice == charecterChoice)
            {
                enemyChoice = UnityEngine.Random.Range(0, 3);
            }
            
        }

        switch (enemyChoice)
        {
            case 0:
                if (charecterChoice == 1)
                {
                    PlayerHit?.Invoke(true);
                    enemyHealth -= 1;
                    EnemyDamage?.Invoke();
                    EnemyHitSound.Invoke();
                }
                if (charecterChoice == 2)
                {
                    DamagePlayer?.Invoke();
                    if(player.PlayerHealth > 0)
                    {
                        EnemyLose?.Invoke(true);
                    }
                    else
                    {
                        ActivePanel?.Invoke(false);
                    }
                    
                }
                break;
                
            case 1:
                if (charecterChoice == 2)
                {
                    PlayerHit?.Invoke(true);
                    enemyHealth -= 1;
                    EnemyDamage?.Invoke();
                    EnemyHitSound.Invoke();
                }
                if (charecterChoice == 0)
                {
                    DamagePlayer?.Invoke();
                    if (player.PlayerHealth > 0)
                    {
                        EnemyLose?.Invoke(true);
                    }
                    else
                    {
                        ActivePanel?.Invoke(false);
                        gameObject.SetActive(false);
                    }
                        
                    
                }
                break;
            case 2:
                if (charecterChoice == 0)
                {
                    PlayerHit?.Invoke(true);
                    enemyHealth -= 1;
                    EnemyDamage?.Invoke();
                    EnemyHitSound.Invoke();
                }
                if (charecterChoice == 1)
                {
                    DamagePlayer?.Invoke();
                    if (player.PlayerHealth > 0)
                    {
                        EnemyLose?.Invoke(true);
                    }
                    else
                    {
                        ActivePanel?.Invoke(false);
                        gameObject.SetActive(false);
                    }
                        
                }
                break;
            default:
                break;
        }
    }
    private void EnemyDeath()
    {
        BattlePanel?.Invoke(false);
        EnemyLose?.Invoke(false);
        PlayerHit?.Invoke(false);
        ActivePanel?.Invoke(false);
        playerController.enabled = true;
        Destroy(swap);
        sprite_charector.enabled = true;
        gameObject.SetActive(false);
        EndPanel?.Invoke(true);
    }
}
