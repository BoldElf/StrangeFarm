using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Thing
{
    key,
    seed,
    plant,
    milk,
    emptyMilk,
    wood,
    axe,
    fhish,
    bone,
    fhishingRod,
    bait,
    zero
}

public class PickupPlayer : MonoBehaviour
{
    [SerializeField] private Thing thing;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject buttonZero;
    [SerializeField] private AudioSource audioPickup;

    public event UnityAction PlayerPickup;

    /*
    public event UnityAction AddMilk;
    public event UnityAction AddKeyHouse;
    public event UnityAction AddSeedBag;
    public event UnityAction AddPlant;
    public event UnityAction AddBowl;
    */
    private Player player;
    private bool playerInCollider = false;

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
            if(button!= null)
            {
                button.SetActive(false);
            }
            if(buttonZero != null)
            {
                buttonZero.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true && playerInCollider == true)
        {
            

            if (thing == Thing.key)
            {
                audioPickup.Play();
                player.AddKeyHouse();
                //AddKeyHouse?.Invoke();
                button.SetActive(true);
                thing = Thing.zero;
                return;
            }
            if (thing == Thing.seed)
            {
                audioPickup.Play();
                player.AddSeedBag();
                //AddSeedBag?.Invoke();
                button.SetActive(true);
                thing = Thing.zero;
                return;
            }
            if(thing == Thing.plant)
            {
                PlantGrowth plantGrowth = GetComponent<PlantGrowth>();
                if(plantGrowth != null && plantGrowth.PlantIsReady == true)
                {
                    audioPickup.Play();
                    //AddPlant?.Invoke();
                    player.AddPlant();
                    PlayerPickup?.Invoke();
                }
            }
            if (thing == Thing.milk)
            {
                audioPickup.Play();
                //AddMilk?.Invoke();
                player.AddMilk();
                gameObject.SetActive(false);
            }
            if (thing == Thing.emptyMilk)
            {
                audioPickup.Play();
                //AddBowl?.Invoke();
                player.AddBowl();
                gameObject.SetActive(false);
            }
            if(thing == Thing.wood)
            {
                audioPickup.Play();
                if(player.Axe == true)
                {
                    player.AddWood();
                    button.SetActive(true);
                    //gameObject.SetActive(false);
                    gameObject.transform.parent.gameObject.SetActive(false);
                }
                else
                {
                    audioPickup.Play();
                    buttonZero.SetActive(true);
                }
                
            }
            if (thing == Thing.axe)
            {
                if(player.Axe == true)
                {
                    thing = Thing.zero;
                    return;
                }
                audioPickup.Play();
                player.AddAxe();
                button.SetActive(true);
            }
            if(thing == Thing.fhish)
            {
                audioPickup.Play();
                player.AddFish();
                gameObject.SetActive(false);
            }
            if (thing == Thing.bone)
            {
                audioPickup.Play();
                player.AddBone();
                gameObject.SetActive(false);
            }
            if(thing == Thing.fhishingRod)
            {
                player.AddFhishingRod();
                button.SetActive(true);
                thing = Thing.zero;
            }
            if(thing == Thing.bait)
            {
                for(int i = 0; i < 4; i++)
                {
                    player.AddFhishingBait();
                }
                thing = Thing.zero;
                button.SetActive(true);
                
            }
            if (thing == Thing.zero)
            {
                audioPickup.Play();
                buttonZero.SetActive(true);
            }
        }

    }

}
