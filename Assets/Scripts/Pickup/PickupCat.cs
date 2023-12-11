using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupCat : MonoBehaviour
{
    private CatController cat;
    private bool catInCollider = false;

    [SerializeField] private GameObject mainObject;

    [SerializeField] private GameObject[] zero_Object;
    [SerializeField] private AudioSource catSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cat = collision.transform.GetComponent<CatController>();

        if (cat != null)
        {
            catInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cat = collision.transform.GetComponent<CatController>();

        if (cat != null)
        {
            catInCollider = false;
        }
    }

    private void Update()
    {
        if(catInCollider == true && mainObject.activeSelf == true)
        {
            catSound.Play();
            mainObject.SetActive(false);
            if(zero_Object[0].activeSelf == false)
            {
                zero_Object[0].SetActive(true);
                return;
            }
            if (zero_Object[0].activeSelf == true && zero_Object[1].activeSelf == false)
            {
                zero_Object[1].SetActive(true); 
            }
            
        }
    }

}
