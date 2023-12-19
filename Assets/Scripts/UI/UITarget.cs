using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITarget : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private GlobalTimer globalTimer;

    private void Start()
    {
        score.text = globalTimer.MaxPlayerCoin.ToString();
    }

}
