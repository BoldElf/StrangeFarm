using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndPanelController : MonoBehaviour
{
    //[SerializeField] private float toOpenContinue;
    //public float ToOpenContinue => toOpenContinue;

    [SerializeField] GlobalTimer globalTimer;


    public event UnityAction buttonOn;

    private void Update()
    {
        if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 100) <= globalTimer.MinimumTime)
        {
            buttonOn?.Invoke();
        }
    }
}
