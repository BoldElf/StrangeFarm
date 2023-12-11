using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushTrigger : MonoBehaviour
{
    private Player player;
    private bool playerInCollider = false;

    [SerializeField] private Collider2D chest;
    [SerializeField] private AudioSource soundTrigger;

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
        if (playerInCollider == true && Input.GetKeyDown(KeyCode.E))
        {
            chest.enabled = true;
            soundTrigger.Play();
            transform.parent.gameObject.SetActive(false);
        }
    }
}
