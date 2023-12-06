using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatDamager : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;

    public event UnityAction CatDamage;

    private DamagePlayer damagePlayer;
    private Player player;

    [SerializeField] private float timeAtack;

    private bool playerInCollider = false;
    private float timer = 10;

    private void Start()
    {
        damagePlayer = playerObj.GetComponent<DamagePlayer>();
        player = playerObj.GetComponent<Player>();

        if (damagePlayer == null || player == null) return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();

        if (player != null)
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
            timer = 10;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;


        if(timer >= timeAtack && playerInCollider == true)
        {
            SetTime();
            CatDamage?.Invoke();
        }
    }

    private void SetTime()
    {
        timer = 0;
    }
}
