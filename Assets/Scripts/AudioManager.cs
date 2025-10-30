using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [Header("Audio Clip")]
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip sfxClip;

    [Header("UI Settings")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    private const string MUSIC_VOLUME_KEY = "Music_Volume";
    private const string SFX_VOLUME_KEY = "Sfx_Volume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        float musicVol = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);
        float sfxVol = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1f);

        SetMusicVolume(musicVol);
        SetSFXVolume(sfxVol);

        if (musicClip != null)
        {
            PlayMusic(musicClip);
        }

        if (musicSlider != null)
        {
            musicSlider.value = musicVol;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = sfxVol;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }
    public void PlayMusic(AudioClip audioClip, bool loop = true)
    {
        if (musicSource == null) return;

        musicSource.clip = audioClip;
        musicSource.loop = loop;
        musicSource.Play();
    }
    public void SetMusicVolume(float volume)
    {
        if (musicSource == null) return;
        musicSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
    }
    public void PlaySFX(AudioClip audioClip)
    {
        if (sfxSource == null || audioClip == null) return;
        sfxSource.PlayOneShot(audioClip);
    }
    public void SetSFXVolume(float volume)
    {
        if (sfxSource == null) return;
        sfxSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat (SFX_VOLUME_KEY, volume);
    }
}
