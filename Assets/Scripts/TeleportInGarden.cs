using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Teleport
{
    house,
    garden
}

public class TeleportInGarden : MonoBehaviour
{
    [SerializeField] private Teleport teleport;
    [SerializeField] private Transform TargetInHouse;
    [SerializeField] private Transform TargetInGarden;
    [SerializeField] private GameObject button_NoKey;

    private Player player;

    private bool playerInCollider = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();

        if(player != null)
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
        if (player == null) return;

        if(player.KeyHouse == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) == true && playerInCollider == true)
            {
                if(teleport == Teleport.house)
                {
                    player.transform.position = TargetInGarden.transform.position;
                }
                if(teleport == Teleport.garden)
                {
                    player.transform.position = TargetInHouse.transform.position;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) == true && playerInCollider == true)
            {
                button_NoKey.SetActive(true);
            }    
        }
        
        
    }
}
