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
    zero
}

public class PickupPlayer : MonoBehaviour
{
    [SerializeField] private Thing thing;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject buttonZero;

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
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true && playerInCollider == true)
        {
            if (thing == Thing.key)
            {
                player.AddKeyHouse();
                //AddKeyHouse?.Invoke();
                button.SetActive(true);
                thing = Thing.zero;
                return;
            }
            if (thing == Thing.seed)
            {
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
                    //AddPlant?.Invoke();
                    player.AddPlant();
                    PlayerPickup?.Invoke();
                }
            }
            if (thing == Thing.milk)
            {
                //AddMilk?.Invoke();
                player.AddMilk();
                gameObject.SetActive(false);
            }
            if (thing == Thing.emptyMilk)
            {
                //AddBowl?.Invoke();
                player.AddBowl();
                gameObject.SetActive(false);
            }
            if (thing == Thing.zero)
            {
                buttonZero.SetActive(true);
            }
        }

    }

}
