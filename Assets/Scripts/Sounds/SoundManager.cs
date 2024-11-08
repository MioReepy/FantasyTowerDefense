using MusicSpase;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO _audioClip;
    private float _volume = 0.5f;
    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeSoundVolume(float volume)
    {
        _volume = volume;
    }
    
    public float GetSoundVolume()
    {
        return _volume;
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