using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text[] text;

    [SerializeField]private GameObject inventoryPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) == true)
        {
            InvetaryOn();
        }
    }

    private void InvetaryOn()
    {
        if(inventoryPanel.activeSelf == false)
        {
            Time.timeScale = 0;
            inventoryPanel.SetActive(true);

            if(player.KeyHouse == true)
            {
                text[0].text = "Yes";
            }
            else
            {
                text[0].text = "No";
            }

            if (player.Axe == true)
            {
                text[1].text = "Yes";
            }
            else
            {
                text[1].text = "No";
            }

            if (player.FhishingRod == true)
            {
                text[2].text = "Yes";
            }
            else
            {
                text[2].text = "No";
            }

            if (player.Scissors == true)
            {
                text[3].text = "Yes";
            }
            else
            {
                text[3].text = "No";
            }

            text[4].text = player.Milk.ToString();
            text[5].text = player.Bowl.ToString();
            text[6].text = player.Wood.ToString();
            text[7].text = player.Seed.ToString();
            text[8].text = player.Fish.ToString();
            text[9].text = player.Bone.ToString();
            text[10].text = player.Plant.ToString();
            text[11].text = player.Bait.ToString();
        }
        else
        {
            Time.timeScale = 1;
            inventoryPanel.SetActive(false);
        }

        
    }
}
