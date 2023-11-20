using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    [SerializeField] private GameObject defaultGarden;
    [SerializeField] private GameObject middleGarden;
    [SerializeField] private GameObject fullGarden;
    [SerializeField] private Pickup pickup;

    [SerializeField] private GameObject SeedZero;

    private Player player;
    private bool playerInCollider = false;

    private bool plantIsReady = false;
    public bool PlantIsReady => plantIsReady;

    private bool startTimer = false;
    private float timer;

    

    private void Start()
    {
        pickup.PlayerPickup += ResetAllGarden;
    }

    private void OnDestroy()
    {
        pickup.PlayerPickup -= ResetAllGarden;
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
        }
    }

    private void FixedUpdate()
    {
        if(startTimer == true)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
        if(timer >= 10)
        {
            middleGarden.SetActive(false);
            startTimer = false;
            timer = 0;
            plantIsReady = true;
        }
    }

    private void Update()
    {
        if (player == null) return;

        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            if (playerInCollider == true && timer == 0 && plantIsReady == false)
            {
                if(player.Seed >= 1)
                {
                    startTimer = true;
                    defaultGarden.SetActive(false);
                    player.MinusSeed();
                    return;
                }

                if (player.Seed == 0)
                {
                    SeedZero.SetActive(true);
                }
            }
            
        }

            
    }

    private void ResetAllGarden()
    {
        defaultGarden.SetActive(true);
        middleGarden.SetActive(true);
        fullGarden.SetActive(true);
        plantIsReady = false;
    }

}
