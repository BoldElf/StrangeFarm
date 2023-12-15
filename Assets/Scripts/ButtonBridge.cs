using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBridge : MonoBehaviour
{
    private Player player;
    private bool playerInCollider = false;

    private bool playerOn = false;

    private float timer;

    [SerializeField] private GameObject buttonOn;
    [SerializeField] private GameObject buttonOff;

    [SerializeField] private MoveLostPart lostPart;

    

    public event UnityAction MoveBridge;
    public event UnityAction NoMoveBridge;

    private void Start()
    {
        lostPart.BridgeReset += LostPart_BridgeReset;
        lostPart.SetActiveButton += setActive;
    }

    private void LostPart_BridgeReset()
    {
        playerOn = false;
        buttonOn.SetActive(false);
        buttonOff.SetActive(true);
    }

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

    private void Update()
    {
        if(playerInCollider == true && playerOn == false)
        {
            setActive();
            MoveBridge?.Invoke();
        }
    }

    private void setActive()
    {
        playerOn = true;
        buttonOff.SetActive(false);
        buttonOn.SetActive(true);
        
    }
}
