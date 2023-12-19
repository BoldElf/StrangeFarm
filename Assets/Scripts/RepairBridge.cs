using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBridge : MonoBehaviour
{
    private Player player;
    private PlayerContoller playerContoller;
    private bool playerInCollider = false;

    [SerializeField] private GameObject buttonNoWood; 

    [SerializeField] private GameObject brokenBridge;
    [SerializeField] private GameObject bridge;

    [SerializeField] private AudioSource repairSound;

    [SerializeField] private int timeToRepair; 

    private float timer;
    private bool startRepair;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();
        playerContoller = collision.transform.GetComponent<PlayerContoller>();
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
                    startRepair = true;
                    repairSound.Play();
                    /*
                    timer = 0;
                    brokenBridge.SetActive(false);
                    bridge.SetActive(true);
                    */
                }
                if(player.Wood < 3)
                {
                    buttonNoWood.SetActive(true);
                }
            }
        }
       
        if(startRepair == true)
        {
            timer += Time.deltaTime;
            playerContoller.enabled = false;
            if (timer >= timeToRepair)
            {
                repair();
            }
        }
    }

    private void repair()
    {
        playerContoller.enabled = true;
        startRepair = false;
        timer = 0;
        brokenBridge.SetActive(false);
        bridge.SetActive(true);
    }
}
