using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _volume = 0.5f;
    public static MusicManager Instance;

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void ChangeMusicVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}