using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantGrowth : MonoBehaviour
{
    [SerializeField] private GameObject defaultGarden;
    [SerializeField] private GameObject middleGarden;
    [SerializeField] private GameObject fullGarden;
    [SerializeField] private PickupPlayer pickup;

    [SerializeField] private GameObject SeedZero;

    [SerializeField] private AudioSource audioNoSeed;


    private Player player;
    private bool playerInCollider = false;

    private bool plantIsReady = false;
    public bool PlantIsReady => plantIsReady;

    private bool startTimer = false;
    private float timer;

    //public event UnityAction MinusSeed;


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
        if(SeedZero != null)
        {
            SeedZero.SetActive(false);
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
        Use();
    }

    private void Use()
    {
        if (player == null) return;

        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            if (playerInCollider == true && timer == 0 && plantIsReady == false)
            {
                
                if (player.Seed >= 1)
                {
                    StartTimer();
                    //player.MinusSeed();
                    //MinusSeed.Invoke();
                    player.MinusSeed();
                    return;
                }
                if (player.Seed == 0)
                {
                    SeedZero.SetActive(true);
                    audioNoSeed.Play();
                }
            }
        }
    }

    private void StartTimer()
    {
        startTimer = true;
        defaultGarden.SetActive(false);
    }

    private void ResetAllGarden()
    {
        defaultGarden.SetActive(true);
        middleGarden.SetActive(true);
        fullGarden.SetActive(true);
        plantIsReady = false;
    }
}
