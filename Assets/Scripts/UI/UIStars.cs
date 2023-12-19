using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStars : MonoBehaviour
{
    [SerializeField] private GlobalTimer globalTimer;

    [SerializeField] private GameObject[] starts;

    void Start()
    {
        globalTimer.MinumTime += GlobalTimer_MinumTime;
        globalTimer.NormTime += GlobalTimer_NormTime;
        globalTimer.MaxTime += GlobalTimer_MaxTime;
    }

    private void GlobalTimer_MinumTime()
    {
        for(int i = 0; i < starts.Length;i++)
        {
            starts[i].SetActive(true);
        }
    }

    private void GlobalTimer_NormTime()
    {
        for (int i = 0; i < 2; i++)
        {
            starts[i].SetActive(true);
        }
    }

    private void GlobalTimer_MaxTime()
    {
        starts[0].SetActive(true);
    }
}
