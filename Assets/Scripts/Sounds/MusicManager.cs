using UnityEngine;

public class MusicManager : MonoBehaviour
{
    internal const string PREFS_MUSIC_EFFECT_VOLUME = "MusicEffectVolume";
    private AudioSource _audioSource;
    public static MusicManager Instance;
    private float _volume;
    
    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        PlayerPrefs.GetFloat(PREFS_MUSIC_EFFECT_VOLUME, 0.5f);
        _audioSource.volume = _volume;
    }

    public void ChangeMusicVolume(float volume)
    {
        _volume = volume;
        PlayerPrefs.SetFloat(PREFS_MUSIC_EFFECT_VOLUME, _volume);
        PlayerPrefs.Save();
        _audioSource.volume = _volume;
    }
}