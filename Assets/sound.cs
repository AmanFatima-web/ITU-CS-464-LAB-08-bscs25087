
using UnityEngine;
using UnityEngine.Audio;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager Instance;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioMixerGroup uiMixerGroup;

    [Header("UI Sound Clips")]
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioClip backSound;
    public AudioClip panelOpenSound;
    public AudioClip panelCloseSound;
    public AudioClip pauseSound;
    public AudioClip resumeSound;
    public AudioClip successSound;
    public AudioClip errorSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource != null && uiMixerGroup != null)
            audioSource.outputAudioMixerGroup = uiMixerGroup;
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
            audioSource.PlayOneShot(clip);
    }

    public void PlayHover() => PlaySound(hoverSound);
    public void PlayClick() => PlaySound(clickSound);
    public void PlayBack() => PlaySound(backSound);
    public void PlayPanelOpen() => PlaySound(panelOpenSound);
    public void PlayPanelClose() => PlaySound(panelCloseSound);
    public void PlayPause() => PlaySound(pauseSound);
    public void PlayResume() => PlaySound(resumeSound);
    public void PlaySuccess() => PlaySound(successSound);
    public void PlayError() => PlaySound(errorSound);
}

