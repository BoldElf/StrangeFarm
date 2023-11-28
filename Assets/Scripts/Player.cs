using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int keyHouse;
    public int KeyHouse => keyHouse;
    private int seed;
    public int Seed => seed;

    private int plant;
    public int Plant => plant;

    private int milk;
    public int Milk => milk;

    private int bowl;
    public int Bowl => bowl;

    private int coin = 20;
    public int Coin => coin;

    public event UnityAction Trade;

    /*
    [SerializeField] private PickupPlayer[] pickupMilk;
    [SerializeField] private PickupPlayer pickupKeyHouse;
    [SerializeField] private PickupPlayer pickupSeed;
    //[SerializeField] private PickupPlayer[] pickupPlants;
    [SerializeField] private GameObject[] gardens;
    //[SerializeField] private PlantGrowth[] minusSeed;
    [SerializeField] private PickupPlayer[] pickupBowl;
    [SerializeField] private CowFeed minusPlant;
    [SerializeField] private Trade[] trades;

    private PlantGrowth[] minusSeed;
    private PickupPlayer[] pickupPlants;

    private void Start()
    {
        minusSeed = new PlantGrowth[gardens.Length];
        pickupPlants = new PickupPlayer[gardens.Length];

        for (int i = 0; i < gardens.Length; i++)
        {
            minusSeed[i] = gardens[i].GetComponent<PlantGrowth>();
        }
        for (int i = 0; i < gardens.Length; i++)
        {
            pickupPlants[i] = gardens[i].GetComponent<PickupPlayer>();
        }
        //////////////////////////////////////////////////////////////////////////////////

        for (int i = 0; i < trades.Length; i++)
        {
            trades[i].TradeSeed += ;
        }

        for (int i = 0; i < pickupMilk.Length;i++)
        {
            pickupMilk[i].AddMilk += AddMilk;
        }
        for (int i = 0; i < pickupPlants.Length; i++)
        {
            pickupPlants[i].AddPlant += AddPlant;
        }
        for (int i = 0; i < minusSeed.Length; i++)
        {
            minusSeed[i].MinusSeed += MinusSeed;
        }
        for (int i = 0; i < pickupBowl.Length; i++)
        {
            pickupBowl[i].AddBowl += AddBowl;
        }

        pickupKeyHouse.AddKeyHouse += AddKeyHouse;
        pickupSeed.AddSeedBag += AddSeedBag;
        minusPlant.MinusPlant += MinusPlant;


    }

    private void OnDestroy()
    {
        for (int i = 0; i < pickupMilk.Length; i++)
        {
            pickupMilk[i].AddMilk -= AddMilk;
        }
        for (int i = 0; i < pickupPlants.Length; i++)
        {
            pickupPlants[i].AddPlant -= AddPlant;
        }
        for (int i = 0; i < minusSeed.Length; i++)
        {
            minusSeed[i].MinusSeed -= MinusSeed;
        }
        for (int i = 0; i < pickupBowl.Length; i++)
        {
            pickupBowl[i].AddBowl -= AddBowl;
        }

        pickupKeyHouse.AddKeyHouse -= AddKeyHouse;
        pickupSeed.AddSeedBag -= AddSeedBag;
        minusPlant.MinusPlant -= MinusPlant;

    }
    */
    public void AddKeyHouse()
    {
        keyHouse += 1;
    }

    public void AddSeedBag()
    {
        seed += 4;
    }
    public void AddPlant()
    {
        plant += 1;
        Debug.Log(plant);
    }
    public void MinusSeed()
    {
        seed -= 1;
    }

    public void MinusPlant()
    {
        plant -= 1;
    }

    public void AddMilk()
    {
        milk += 1;
        Debug.Log(Milk);
    }

    public void AddBowl()
    {
        bowl += 1;
        Debug.Log(bowl);
    }

    
    //Trade zone
    
    public void SellBowl()
    {
        bowl -= 1;
        coin += 5;
        Trade?.Invoke();
    }

    public void SellMilk()
    {
        milk -= 1;
        coin += 20;
        Trade?.Invoke();
    }

    public void TradeSeed()
    {
        seed += 4;
        coin -= 20;
        Trade?.Invoke();
        Debug.Log(seed);
    }
}
