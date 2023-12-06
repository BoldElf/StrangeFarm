using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBridge : MonoBehaviour
{
    private Player player;
    private bool playerInCollider = false;

    [SerializeField] private GameObject buttonNoWood; 

    [SerializeField] private GameObject brokenBridge;
    [SerializeField] private GameObject bridge;

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
            buttonNoWood.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInCollider == true)
        {
            if (Input.GetKeyDown(KeyCode.E) == true)
            {
                if(player.Wood >= 3)
                {
                    brokenBridge.SetActive(false);
                    bridge.SetActive(true);
                }
                if(player.Wood < 3)
                {
                    buttonNoWood.SetActive(true);
                }
            }
        }
    }
}
