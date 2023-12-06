using System;
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

    private int wood;
    public int Wood => wood;

    private bool axe = false;
    public bool Axe => axe;

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

    public void AddWood()
    {
        wood += 1;
        Debug.Log(wood);
    }

    public void AddAxe()
    {
        axe = true;
        Debug.Log(axe);
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
