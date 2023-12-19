using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fishing : MonoBehaviour
{
    private Player player;
    private bool playerInCollider = false;

    private SpriteRenderer sprite;
    private PlayerContoller playerContoller;

    [SerializeField] private GameObject prefabFishing;

    [SerializeField] private GameObject[] fhishingPlaces;

    [SerializeField] private AudioSource castFishingSound;
    [SerializeField] private AudioSource spawnFishSound;

    public event UnityAction<bool> fhishingOnOrOff;

    private GameObject FishingCharector;

    private bool spawn;
    private float timer;

    private void Start()
    {
        for (int i = 0; i < fhishingPlaces.Length; i++)
        {
            fhishingPlaces[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();

        if (player != null)
        {
            sprite = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
            playerContoller = collision.GetComponentInChildren<PlayerContoller>();
            playerInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();

        if (player != null)
        {
            playerInCollider = false;
            //buttonZeroRod.SetActive(false);
            fhishingOnOrOff?.Invoke(false);
        }
    }

    private void Update()
    {
        if(playerInCollider == true && Input.GetKeyDown(KeyCode.E) == true)
        {
            if(player.FhishingRod == true && player.Bait >= 1)
            {
                sprite.enabled = false;
                playerContoller.enabled = false;

                if(spawn == false)
                {
                    castFishingSound.Play();
                    spawnPrefab();
                    startTimer();
                }
            }
            else
            {
                //buttonZeroRod.SetActive(true);
                fhishingOnOrOff?.Invoke(true);
            }
            
        }
        if(spawn == true)
        {
            timer += Time.deltaTime;
            if(timer > 5)
            {
                spawnFish();
                replaceCharector();
                spawn = false;
            }
        }
    }

    private void spawnPrefab()
    {
        spawn = true;
        FishingCharector = Instantiate(prefabFishing, player.transform);
    }
    private void startTimer()
    {
        timer = 0;
    }

    private void spawnFish()
    {
        spawnFishSound.Play();
        player.MinusBait();
        for(int i = 0; i < fhishingPlaces.Length; i++)
        {
            if(fhishingPlaces[i].activeSelf == false)
            {
                fhishingPlaces[i].SetActive(true);
                return;
            }
        }

    }
    private void replaceCharector()
    {
        sprite.enabled = true;
        playerContoller.enabled = true;
        Destroy(FishingCharector);
    }
}
