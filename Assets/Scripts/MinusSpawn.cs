using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusSpawn : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] private GameObject prefabMinus;
    private GameObject prefabSave;

    void Start()
    {
        player.MinusSpawn += Player_Minus;
    }

    private void Player_Minus()
    {
        prefabSave = Instantiate(prefabMinus, gameObject.transform);
        Destroy(prefabSave, 3);
    }
}
