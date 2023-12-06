using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingSaverMusicSound : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string mixerParametr;

    private float abc;

    private void Awake()
    {
        abc = PlayerPrefs.GetFloat(mixerParametr, 0);
    }

    private void Start()
    {
        audioMixer.SetFloat(mixerParametr, abc);
    }

}
