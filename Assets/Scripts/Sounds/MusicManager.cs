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

    public void OnMouseButtonClick()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.ClickButtonSound, Camera.main.transform.position, 1f);
        }
    }
    
    public void CrossbowShotSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.CrossbowShotSound, Camera.main.transform.position, 1f);
        }
    }    
    
    public void MortalShotSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.MortalShotSound, Camera.main.transform.position, 1f);
        }
    }    
    
    public void CrystalShotSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.CrystalShotSound, Camera.main.transform.position, 1f);
        }
    }

    public void TeslaShotSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.TeslaShotSound, Camera.main.transform.position, 1f);
        }
    }

    public void PlayerDamageSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.PlayerDamageSound, Camera.main.transform.position, 1f);
        }
    }
    public void EnemyDieSound()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.EnemyDieSound, Camera.main.transform.position, 1f);
        }
    }
}