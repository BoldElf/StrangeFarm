using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDamager : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;

    private DamagePlayer damagePlayer;
    private Player player;

    private void Start()
    {
        damagePlayer = playerObj.GetComponent<DamagePlayer>();
        player = playerObj.GetComponent<Player>();

        if (damagePlayer == null || player == null) return;
    }
}
