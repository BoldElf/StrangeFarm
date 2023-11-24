using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CowFeed : MonoBehaviour
{

    [SerializeField] private GameObject defaultDish;
    [SerializeField] private GameObject normalDish;
    [SerializeField] private GameObject fullDish;
    //[SerializeField] private Pickup pickup;

    [SerializeField] private GameObject PlantZero;

    public event UnityAction AddMilk;


    private Player player;
    private bool playerInCollider = false;

    private bool plantIsReady = false;
    public bool PlantIsReady => plantIsReady;

    private bool startTimer = false;
    private float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();

        if (player != null)
        {
            playerInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = collision.transform.GetComponent<Player>();

        if (player != null)
        {
            playerInCollider = false;
        }
    }

    private void FixedUpdate()
    {
        if (startTimer == true)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }

        if (timer >= 5 && timer < 10)
        {
            fullDish.SetActive(false);
        }

        if (timer >= 10)
        {
            normalDish.SetActive(false);
            ResetAllDish();
            AddMilk?.Invoke();
            startTimer = false;
            timer = 0;
            plantIsReady = true;
        }
    }

    private void Update()
    {
        Use();
    }

    private void Use()
    {
        if (player == null) return;

        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            if(playerInCollider == true && timer == 0)
            {
                if (player.Plant >= 1)
                {
                    StartTimer();
                    player.MinusPlant();
                    return;
                }
                if (player.Plant == 0)
                {
                    PlantZero.SetActive(true);
                }
            }
        }
    }

    private void StartTimer()
    {
        startTimer = true;
        defaultDish.SetActive(false);
    }

    private void ResetAllDish()
    {
        defaultDish.SetActive(true);
        normalDish.SetActive(true);
        fullDish.SetActive(true);
    }
}
