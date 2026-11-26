
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider uiSlider;

    void Start()
    {
        LoadVolume("MyExposedParam", masterSlider);
        LoadVolume("MyExposedParam 1", musicSlider);
        LoadVolume("MyExposedParam 2", sfxSlider);
        LoadVolume("MyExposedParam 3", uiSlider);
    }

    void LoadVolume(string parameter, Slider slider)
    {
        if (slider == null) return;

        float value = PlayerPrefs.GetFloat(parameter, 1f);
        slider.value = value;
        SetVolume(parameter, value);
    }

    public void SetMasterVolume(float value)
    {
        SetVolume("MyExposedParam", value);
    }

    public void SetMusicVolume(float value)
    {
        SetVolume("MyExposedParam 1", value);
    }

    public void SetSFXVolume(float value)
    {
        SetVolume("MyExposedParam 2", value);
    }

    public void SetUIVolume(float value)
    {
        SetVolume("MyExposedParam 3", value);
    }

    void SetVolume(string parameter, float value)
    {
        float db = value <= 0.0001f
            ? -80f
            : Mathf.Log10(value) * 20f;

        audioMixer.SetFloat(parameter, db);

        PlayerPrefs.SetFloat(parameter, value);
        PlayerPrefs.Save();
    }
}
