using MusicSpase;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO _audioClip;

    public void OnMouseButtonClick()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip.ClickButtonSound, Camera.main.transform.position, 1f);
        }
    }
}
