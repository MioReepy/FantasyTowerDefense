using UnityEngine;

namespace MusicSpase
{
    [CreateAssetMenu(fileName = "Audio Clip", menuName = "ScriptableObject/Audio Clip")]
    public class AudioClipSO : ScriptableObject
    {
        public AudioClip ClickButtonSound;
    }
}