using UnityEngine;

public class MusicManager : MonoBehaviour
{
    internal const string PREFS_MUSIC_EFFECT_VOLUME = "MusicEffectVolume";
    private AudioSource _audioSource;
    public static MusicManager Instance;

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        PlayerPrefs.GetFloat(PREFS_MUSIC_EFFECT_VOLUME, 0.5f);
    }

    public void ChangeMusicVolume(float volume)
    {
        _audioSource.volume = volume;
        PlayerPrefs.SetFloat(PREFS_MUSIC_EFFECT_VOLUME, _audioSource.volume);
        PlayerPrefs.Save();
    }
}