using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMilk : MonoBehaviour
{
    [SerializeField]private GameObject  milk_00;
    [SerializeField] private GameObject milk_01;
    [SerializeField] private GameObject milk_02;

    [SerializeField] private CowFeed cowFeed;

    private void Start()
    {
        cowFeed.AddMilk += spawnMilk;
    }

    private void spawnMilk()
    {
        if(milk_00.activeSelf == true && milk_01.activeSelf == false)
        {
            milk_01.SetActive(true);
            return;
        }
        if(milk_01.activeSelf == true)
        {
            milk_02.SetActive(true);
            return;
        }
        else
        {
            milk_00.SetActive(true);
        }
    }

}
