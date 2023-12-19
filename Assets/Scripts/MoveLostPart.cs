using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveLostPart : MonoBehaviour
{
    [SerializeField] private ButtonBridge[] bridgePanels;
    [SerializeField] private Transform positionToMove;
    [SerializeField] private Collider2D[] bridgeCollider;
    [SerializeField] private Transform startPosition;

    [SerializeField] private GameObject lostPark;

    [SerializeField]private float value;

    private bool moveToStart = false;
    private float timer;

    public event UnityAction BridgeReset;
    public event UnityAction SetActiveButton;

    [SerializeField] private GameObject soundMove;

    private void Start()
    {
        enabled = false;
        for (int i = 0; i < bridgePanels.Length; i++)
        {
            bridgePanels[i].MoveBridge += Bridge_MoveBridge;
        }
            
    }

    private void OnDestroy()
    {
        for (int i = 0; i < bridgePanels.Length; i++)
        {
            bridgePanels[i].MoveBridge -= Bridge_MoveBridge;
        }
    }

    private void Bridge_MoveBridge()
    {
        SetActiveButton?.Invoke();

        enabled = true;
    }

    private void Update()
    {
        if(moveToStart == false)
        {
            soundMove.SetActive(true);
            lostPark.transform.position = Vector2.MoveTowards(lostPark.transform.position, positionToMove.transform.position, 1.0f * Time.deltaTime);
        }
        
        if(lostPark.transform.position == positionToMove.transform.position)
        {
            soundMove.SetActive(false);
            for (int i = 0; i < bridgeCollider.Length;i++)
            {
                bridgeCollider[i].enabled = false;
            }
            
            timer += Time.deltaTime;
            moveToStart = true;
        }
        else
        {
            for (int i = 0; i < bridgeCollider.Length; i++)
            {
                bridgeCollider[i].enabled = true;
            }
        }

        if(timer >= value)
        {
            soundMove.SetActive(true);
            lostPark.transform.position = Vector2.MoveTowards(lostPark.transform.position, startPosition.transform.position, 1.0f * Time.deltaTime);

            if(lostPark.transform.position == startPosition.transform.position && moveToStart == true)
            {
                soundMove.SetActive(false);
                timer = 0;
                BridgeReset?.Invoke();
                moveToStart = false;
                enabled = false;
            }
        }
    }
}
