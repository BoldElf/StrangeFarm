using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPausePanel : MonoBehaviour
{
    public void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
