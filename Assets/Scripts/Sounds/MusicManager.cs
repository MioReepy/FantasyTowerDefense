using System;
using MusicSpase;
using TowerSpace;
using UISpace;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO _audioClip;
    public static MusicManager Instance;

    private void Awake()
    {
        Instance = this;
        MainMenu.OnMusicOn += MainMenu_OnMusicOn;
        StartLevel.OnMusicOn += StartLevel_OnMusicOn;
    }

    private void MainMenu_OnMusicOn(object sender, EventArgs e)
    {
        AudioSource.PlayClipAtPoint(_audioClip.mainMenyMusic, Camera.main.transform.position, 0.5f);
    }

    private void StartLevel_OnMusicOn(object sender, EventArgs e)
    {
        AudioSource.PlayClipAtPoint(_audioClip.LevelMusic, Camera.main.transform.position, 0.5f);
    }
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
