using MusicSpase;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO _audioClip;
    public static MusicManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}
