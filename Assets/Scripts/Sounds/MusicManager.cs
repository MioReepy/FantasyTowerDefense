using UnityEngine;

public class MusicManager : MonoBehaviour
{
    internal const string PrefsMusicEffectVolume = "MusicEffectVolume";
    private AudioSource _audioSource;
    public static MusicManager Instance;
    private float _volume;
    
    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        PlayerPrefs.GetFloat(PrefsMusicEffectVolume, 0.5f);
        _audioSource.volume = _volume;
    }

    public void ChangeMusicVolume(float volume)
    {
        _volume = volume;
        PlayerPrefs.SetFloat(PrefsMusicEffectVolume, _volume);
        PlayerPrefs.Save();
        _audioSource.volume = _volume;
    }
}