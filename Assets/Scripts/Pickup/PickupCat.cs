using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupCat : MonoBehaviour
{
    private CatController cat;
    private Player player;
    private bool catInCollider = false;
    [SerializeField] private GameObject[] zero_milk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();
        if (player != null) return;

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
        if(catInCollider == true)
        {
            gameObject.SetActive(false);
            if(zero_milk[0].activeSelf == false)
            {
                zero_milk[0].SetActive(true);
                return;
            }
            if (zero_milk[0].activeSelf == true && zero_milk[1].activeSelf == false)
            {
                zero_milk[1].SetActive(true);
            }
            
        }
    }

}
