using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpawnPrefs : MonoBehaviour
{
    Player player;
    [SerializeField] private GameObject prefabMinus;
    [SerializeField] private GameObject prefabPlus;
    [SerializeField] private GameObject prefabHit;
    [SerializeField] private GameObject pefabTrade;

    [SerializeField] private GameObject canvas;

    private GameObject prefabSaveMinus;
    private GameObject prefabSavePlus;
    private GameObject prefabSaveHit;
    private GameObject prefabSaveTrade;

    void Start()
    {
        player = gameObject.GetComponent<Player>();
        player.MinusSpawn += Player_Minus;
        player.SpawnPlus += Player_SpawnPlus;
        player.DamagePlayer += Player_DamagePlayer;
        player.Trade += Player_Trade;
    }

    private void Player_Minus()
    {
        prefabSaveMinus = Instantiate(prefabMinus, gameObject.transform);
        Destroy(prefabSaveMinus, 1);
    }

    private void Player_SpawnPlus()
    {
        prefabSavePlus = Instantiate(prefabPlus, gameObject.transform);
        Destroy(prefabSavePlus, 1);
    }
    private void Player_DamagePlayer()
    {
        prefabSaveHit = Instantiate(prefabHit, canvas.transform);
        Destroy(prefabSaveHit, 0.1f);
    }
    private void Player_Trade()
    {
        prefabSaveTrade = Instantiate(pefabTrade, gameObject.transform);
        Destroy(prefabSaveTrade, 3f);
    }
}
