using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelObject : MonoBehaviour
{

    [SerializeField] private GlobalTimer globalTimer;
    [SerializeField] private GameObject buttonNoCoin;
    [SerializeField] private AudioSource notification;
    private Player player;
    private bool playerInCollider = false;

    private bool maxCoin = false;

    private void Start()
    {
        globalTimer.endCoin += GlobalTimer_endCoin;
    }

    private void GlobalTimer_endCoin()
    {
        maxCoin = true;
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
            buttonNoCoin.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true && playerInCollider == true)
        {
            if(maxCoin == true)
            {
                globalTimer.setActiveText();
            }
            else
            {
                notification.Play();
                buttonNoCoin.SetActive(true);
            }
            
        }
    }
}
