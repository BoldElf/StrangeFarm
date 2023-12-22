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

    private void Start()
    {
        damagePlayer = gameObject.GetComponent<DamagePlayer>();
        damagePlayer.PlayerMinusHealth += playerMinusHealth;
    }

    private void playerMinusHealth()
    {
        playerHealt -= 1;
        DamagePlayer?.Invoke();
    }

    public void AddKeyHouse()
    {
        keyHouse = true;
    }

    public void AddCoin(int value)
    {
        coin += value;
        Trade?.Invoke();
    }

    public void AddScissors()
    {
        scissors = true;
    }

    public void AddSeedBag()
    {
        seed += 4;
    }
    public void AddPlant()
    {
        plant += 1;
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
    }

    public void AddBowl()
    {
        bowl += 1;
    }

    public void AddWood()
    {
        wood += 1;
    }

    public void AddAxe()
    {
        axe = true;
    }

    public void AddFish()
    {
        fish += 1;
    }

    public void MinusFish()
    {
        fish -= 1;
    }

    public void AddBone()
    {
        bone += 1;
    }

    public void AddFhishingRod()
    {
        fhishingRod = true;
    }

    public void AddFhishingBait()
    {
        bait += 1;
    }
    public void MinusBait()
    {
        bait -= 1;
    }

    public void MinusBone()
    {
        bone -= 1;
    }

    public void MinusWood()
    {
        wood -= 3;
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
    }
}
