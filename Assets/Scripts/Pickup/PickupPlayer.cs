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
    scissors,
    zero
}

public class PickupPlayer : MonoBehaviour, IDependencies<UINotification>
{
    [SerializeField] private Thing thing;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject buttonZero;
    [SerializeField] private AudioSource audioPickup;

    [SerializeField]private UINotification UINotification;

    public void Construct(UINotification obj) => UINotification = obj;

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

    private void Start()
    {
        UINotification.setUi(0.ToString(), 0.ToString());
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
        if (Input.GetKeyDown(KeyCode.E) == true && playerInCollider == true && player != null)
        {
            if (thing == Thing.key)
            {
                audioPickup.Play();
                player.AddKeyHouse();
                button.SetActive(true);
                UINotification.setUi("+1","key");
                thing = Thing.zero;
                return;
            }
            if (thing == Thing.seed)
            {
                audioPickup.Play();
                player.AddSeedBag();
                button.SetActive(true);
                UINotification.setUi("+4", "seed");
                thing = Thing.zero;
                return;
            }
            if(thing == Thing.plant)
            {
                PlantGrowth plantGrowth = GetComponent<PlantGrowth>();
                if(plantGrowth != null && plantGrowth.PlantIsReady == true)
                {
                    audioPickup.Play();
                    UINotification.setUi("+1", "plant");
                    player.AddPlant();
                    PlayerPickup?.Invoke();
                    return;
                }
            }
            if (thing == Thing.milk)
            {
                audioPickup.Play();
                UINotification.setUi("+1", "milk");
                player.AddMilk();
                gameObject.SetActive(false);
                return;
            }
            if (thing == Thing.emptyMilk)
            {
                audioPickup.Play();
                UINotification.setUi("+1", "container");
                player.AddBowl();
                gameObject.SetActive(false);
                return;
            }
            if(thing == Thing.wood)
            {
                audioPickup.Play();
                if(player.Axe == true)
                {
                    player.AddWood();
                    UINotification.setUi("+1", "wood");
                    button.SetActive(true);
                    gameObject.transform.parent.gameObject.SetActive(false);
                    return;
                }
                else
                {
                    audioPickup.Play();
                    buttonZero.SetActive(true);
                    return;
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
                UINotification.setUi("+1", "axe");
                player.AddAxe();
                button.SetActive(true);
                return;
            }
            if(thing == Thing.fhish)
            {
                audioPickup.Play();
                UINotification.setUi("+1", "fhish");
                player.AddFish();
                gameObject.SetActive(false);
                return;
            }
            if (thing == Thing.bone)
            {
                audioPickup.Play();
                UINotification.setUi("+1", "bone");
                player.AddBone();
                gameObject.SetActive(false);
                return;
            }
            if(thing == Thing.fhishingRod)
            {
                audioPickup.Play();
                UINotification.setUi("+1", "rod");
                player.AddFhishingRod();
                button.SetActive(true);
                thing = Thing.zero;
                return;
            }
            if(thing == Thing.bait)
            {
                for(int i = 0; i < 4; i++)
                {
                    player.AddFhishingBait();
                }
                UINotification.setUi("+4", "bait");
                thing = Thing.zero;
                button.SetActive(true);
                return;
            }
            if(thing == Thing.scissors)
            {
                audioPickup.Play();
                UINotification.setUi("+1", "scissors");
                player.AddScissors();
                button.SetActive(true);
                thing = Thing.zero;
                return;
            }
            if (thing == Thing.zero)
            {
                audioPickup.Play();
                buttonZero.SetActive(true);
                return;
            }
        }

    }

}
