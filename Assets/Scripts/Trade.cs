using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trade : MonoBehaviour
{
    [SerializeField] private GameObject TradeMenu;

    private Player player;
    private bool playerInCollider = false;

    //public event UnityAction TradeSeed;

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
        }
    }

    private void Update()
    {
        if(playerInCollider == true)
        {
            if (Input.GetKeyDown(KeyCode.E) == true)
            {
                TradeMenu.SetActive(true);
            }
        }
        if(playerInCollider == false)
        {
            TradeMenu.SetActive(false);
        }
        
    }
}
