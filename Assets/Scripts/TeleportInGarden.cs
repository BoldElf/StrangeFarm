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
    [SerializeField] private AudioSource doorAudio;

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
            button_NoKey.SetActive(false);
        }
        if(player.KeyHouse == true && button_NoKey != null)
        {
            //button_NoKey.SetActive(false);
        }
    }

    private void Update()
    {
        if (player == null) return;

        if(player.KeyHouse == true)
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
                doorAudio.Play();
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
