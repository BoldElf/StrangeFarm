using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusSpawn : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] private GameObject prefabPlus;
    private GameObject prefabSave;

    void Start()
    {
        //pickupPlayer.SpawnPlus += PickupPlayer_SpawnPlus;
        player.SpawnPlus += Player_SpawnPlus;
    }

    private void Player_SpawnPlus()
    {
        prefabSave = Instantiate(prefabPlus, gameObject.transform);
        Destroy(prefabSave, 3);
    }
}
