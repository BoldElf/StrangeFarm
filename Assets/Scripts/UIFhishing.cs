using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFhishing : MonoBehaviour
{
    private Fishing fishing;
    [SerializeField] private GameObject buttonZeroRod;
    [SerializeField] private AudioSource buttonSound;
    private void Start()
    {
        fishing = gameObject.GetComponent<Fishing>();
        fishing.fhishingOnOrOff += buttonSetActive;
    }

    private void buttonSetActive(bool value)
    {
        buttonZeroRod.SetActive(value);

        if(value == true)
        {
            buttonSound.Play();
        }
    }
}
