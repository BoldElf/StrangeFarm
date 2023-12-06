using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeart : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Player player;
    //[SerializeField] private DamagePlayer damagePlayer;

    private int positionX = -500;
    private GameObject[] hearts;

    private void Start()
    {
        hearts = new GameObject[player.PlayerHealth];
        player.DamagePlayer += ResetHeart;
        heartDrow();
    }

    private void heartDrow()
    {

        for (int i = 0; i < player.PlayerHealth; i++)
        {
            hearts[i] = Instantiate(heartPrefab);
            hearts[i].transform.SetParent(gameObject.transform);

            if(i < 3)
            {
                hearts[i].transform.localPosition = new Vector3(positionX, 200, 0);
            }

            if (i >= 3 && i < 6)
            {
                hearts[i].transform.localPosition = new Vector3(positionX, 0, 0);
            }

            if (i >= 6 && i < 9)
            {
                hearts[i].transform.localPosition = new Vector3(positionX, -200, 0);
            }

            positionX += 500;
            if (positionX > 500)
            {
                positionX = -500;
            }
        }
        positionX = -500;
    }

    private void ResetHeart()
    {
        DeleatAll();
        heartDrow();
    }

    private void DeleatAll()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            Destroy(hearts[i]);
        }
    }
}
