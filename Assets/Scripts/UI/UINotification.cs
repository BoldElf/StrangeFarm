using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINotification : MonoBehaviour
{
    [SerializeField] private Text numberUI;
    [SerializeField] private Text materialUI;

    [SerializeField] private GameObject main;

    private float timer;
    [SerializeField]private float timerToHide;

    private void Start()
    {
        enabled = false;
    }

    public void setUi(string number,string material)
    {
        if (number == "0" && material == "0")
        {
            timer = 0;
            enabled = true;
            numberUI.text = number;
            materialUI.text = material;
            main.SetActive(true);
            main.SetActive(false);
            return;
        }
        timer = 0;
        enabled = true;
        numberUI.text = number;
        materialUI.text = material;
        main.SetActive(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timerToHide)
        {
            main.SetActive(false);
            timer = 0;
            enabled = false;
        }
    }
}
