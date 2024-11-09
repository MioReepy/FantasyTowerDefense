using MusicSpase;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    internal const string PrefsSoundEffectVolume = "SoundEffectVolume";
    [SerializeField] private AudioClipSO _audioClip;
    private float _volume;
    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
        _volume = PlayerPrefs.GetFloat(PrefsSoundEffectVolume, 0.5f);
    }

    public void ChangeSoundVolume(float volume)
    {
        _volume = volume;
        PlayerPrefs.SetFloat(PrefsSoundEffectVolume, _volume);
        PlayerPrefs.Save();
    }
    
    public void OnMouseButtonClick()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.ClickButtonSound, Camera.main.transform.position, _volume);
        }
    }
    
    public void CrossbowShotSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.CrossbowShotSound, Camera.main.transform.position, _volume);
        }
    }    
    
    public void MortalShotSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.MortalShotSound, Camera.main.transform.position, _volume);
        }
    }    
    
    public void CrystalShotSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.CrystalShotSound, Camera.main.transform.position, _volume);
        }
    }

    public void TeslaShotSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.TeslaShotSound, Camera.main.transform.position, _volume);
        }
    }

    public void PlayerDamageSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.PlayerDamageSound, Camera.main.transform.position, _volume);
        }
    }
    public void EnemyDieSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.EnemyDieSound, Camera.main.transform.position, _volume);
        }
    }    
    public void TowerBuildingSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.TowerBuildingSound, Camera.main.transform.position, _volume);
        }
    }
    public void TowerSelectedTower()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.TowerSelectedTower, Camera.main.transform.position, _volume);
        }
    }
}