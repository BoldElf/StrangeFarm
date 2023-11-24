using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Thing
{
   key,
   seed,
   plant,
   zero,
   milk
}

public class Pickup : MonoBehaviour
{
    [SerializeField] private Thing thing;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject buttonZero;

    public event UnityAction PlayerPickup;

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
                button.SetActive(true);
                thing = Thing.zero;
                return;
            }
            if (thing == Thing.seed)
            {
                player.AddSeedBag();
                button.SetActive(true);
                thing = Thing.zero;
                return;
            }
            if(thing == Thing.plant)
            {
                PlantGrowth plantGrowth = GetComponent<PlantGrowth>();
                if(plantGrowth != null && plantGrowth.PlantIsReady == true)
                {
                    player.AddPlant();
                    PlayerPickup?.Invoke();
                }
            }
            if(thing == Thing.milk)
            {
                player.AddMilk();
                gameObject.SetActive(false);
            }
            if (thing == Thing.zero)
            {
                buttonZero.SetActive(true);
            }
        }

    }

}
