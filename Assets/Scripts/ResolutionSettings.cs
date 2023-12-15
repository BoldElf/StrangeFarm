using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    [SerializeField] private Text text;

    [SerializeField]
    private Vector2Int[] avalibalResolutions = new Vector2Int[]
    {
        new Vector2Int(800,600),
        new Vector2Int(1280,720),
        new Vector2Int(1600,900),
        new Vector2Int(1920,1080)
    };

    private int currentResolutionIndex = 0;

    public  bool isMinValue { get => currentResolutionIndex == 0; }
    public  bool isMaxValue { get => currentResolutionIndex == avalibalResolutions.Length - 1; }

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        GetValue();
    }

    public  void SetNextValue()
    {
        if (isMaxValue == false)
        {
            currentResolutionIndex++;
        }
    }
    public  void SetPreviousValue()
    {
        if (isMinValue == false)
        {
            currentResolutionIndex--;
        }
    }
    public void GetValue()
    {
        //return avalibalResolutions[currentResolutionIndex];
        text.text = GetStringValue();
    }

    public  string GetStringValue()
    {
        return avalibalResolutions[currentResolutionIndex].x + "x" + avalibalResolutions[currentResolutionIndex].y;
    }

    public  void Applay()
    {
        Screen.SetResolution(avalibalResolutions[currentResolutionIndex].x, avalibalResolutions[currentResolutionIndex].y, true);
        PlayerPrefs.SetInt("settings", currentResolutionIndex);
    }

    private void Load()
    {
        currentResolutionIndex = PlayerPrefs.GetInt("settings",3);
        Screen.SetResolution(avalibalResolutions[currentResolutionIndex].x, avalibalResolutions[currentResolutionIndex].y, true);
    }
}
