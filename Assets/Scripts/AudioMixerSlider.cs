using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerSlider : MonoBehaviour
{
    private const float DisabledVolume = -80;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private string mixerParametr;
    [SerializeField] private float minimumVolume;

    //public static string SaveMarkMusic = "music";

    private float startMixerSetting;
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat(mixerParametr, 0));
        startMixerSetting = PlayerPrefs.GetFloat(mixerParametr, 0);
        
        audioMixer.SetFloat(mixerParametr, startMixerSetting);

        volumeSlider.SetValueWithoutNotify(GetMixerVolume());
    }

    public void UpdateMixerVolume(float volumeValue)
    {
        SetMixerVolume(volumeValue);
    }

    private void SetMixerVolume(float volumeValue)
    {
        float mixerVolume;

        if (volumeValue == 0)
        {
            mixerVolume = DisabledVolume;
        }
        else
        {
            mixerVolume = Mathf.Lerp(minimumVolume, 0, volumeValue);
            audioMixer.SetFloat(mixerParametr, mixerVolume);
            PlayerPrefs.SetFloat(mixerParametr,mixerVolume );
        }
    }

    private float GetMixerVolume()
    {
        //audioMixer.GetFloat(mixerParametr, out float mixerVolume);
        if (startMixerSetting == DisabledVolume)
        {
            return 0;
        }
        else
        {
            return Mathf.Lerp(1, 0, startMixerSetting / minimumVolume);
        }
    }
}
