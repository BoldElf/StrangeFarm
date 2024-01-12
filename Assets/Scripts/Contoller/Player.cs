using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private bool keyHouse;
    public bool KeyHouse => keyHouse;
    private int seed;
    public int Seed => seed;

    private int plant;
    public int Plant => plant;

    private int milk;
    public int Milk => milk;

    private int bowl;
    public int Bowl => bowl;

    private int coin;
    public int Coin => coin;

    private int wood;
    public int Wood => wood;

    private bool axe = false;
    public bool Axe => axe;

    private bool fhishingRod = false;
    public bool FhishingRod => fhishingRod;

    private int bait;
    public int Bait => bait;

    private int fish;
    public int Fish => fish;

    private int bone;
    public int Bone => bone;

    private bool scissors;
    public bool Scissors => scissors;

    public event UnityAction Trade;

    private DamagePlayer damagePlayer;

    [SerializeField]private int playerHealt;
    public int PlayerHealth => playerHealt;

    public event UnityAction DamagePlayer;
    public event UnityAction MinusSpawn;
    public event UnityAction SpawnPlus;

    private void Start()
    {
        damagePlayer = gameObject.GetComponent<DamagePlayer>();
        damagePlayer.PlayerMinusHealth += playerMinusHealth;
    }

    private void playerMinusHealth()
    {
        MinusSpawn?.Invoke();
        playerHealt -= 1;
        DamagePlayer?.Invoke();
    }

    public void AddKeyHouse()
    {
        SpawnPlus?.Invoke();
        keyHouse = true;
    }

    public void AddCoin(int value)
    {
        SpawnPlus?.Invoke();
        coin += value;
        Trade?.Invoke();
    }

    public void AddScissors()
    {
        scissors = true;
    }

    public void AddSeedBag()
    {
        SpawnPlus?.Invoke();
        seed += 4;
    }
    public void AddPlant()
    {
        SpawnPlus?.Invoke();
        plant += 1;
    }
    public void MinusSeed()
    {
        MinusSpawn?.Invoke();
        seed -= 1;
    }

    public void MinusPlant()
    {
        MinusSpawn?.Invoke();
        plant -= 1;
    }

    public void AddMilk()
    {
        SpawnPlus?.Invoke();
        milk += 1;
    }

    public void AddBowl()
    {
        SpawnPlus?.Invoke();
        bowl += 1;
    }

    public void AddWood()
    {
        SpawnPlus?.Invoke();
        wood += 1;
    }

    public void AddAxe()
    {
        SpawnPlus?.Invoke();
        axe = true;
    }

    public void AddFish()
    {
        SpawnPlus?.Invoke();
        fish += 1;
    }

    public void MinusFish()
    {
        MinusSpawn?.Invoke();
        fish -= 1;
    }

    public void AddBone()
    {
        SpawnPlus?.Invoke();
        bone += 1;
    }

    public void AddFhishingRod()
    {
        SpawnPlus?.Invoke();
        fhishingRod = true;
    }

    public void AddFhishingBait()
    {
        SpawnPlus?.Invoke();
        bait += 1;
    }
    public void MinusBait()
    {
        MinusSpawn?.Invoke();
        bait -= 1;
    }

    public void MinusBone()
    {
        MinusSpawn?.Invoke();
        bone -= 1;
    }

    public void MinusWood()
    {
        MinusSpawn?.Invoke();
        wood -= 3;
    }

    //Trade zone

    public void BoneOnBait()
    {
        bone -= 1;
        bait += 1;
        Trade?.Invoke();
    }

    public void FishOnCoin()
    {
        fish -= 1;
        coin += 10;
        Trade?.Invoke();
    }

    public void BuyScissors(int costOfScissors)
    {
        scissors = true;
        coin += costOfScissors;
        Trade?.Invoke();
    }

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
    }
}
