using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int keyHouse;
    public int KeyHouse => keyHouse;
    private int seed;
    public int Seed => seed;

    private int plant;
    public int Plant => plant;

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
}
