using UnityEngine;

namespace MusicSpase
{
    [CreateAssetMenu(fileName = "Audio Clip", menuName = "ScriptableObject/Audio Clip")]
    public class AudioClipSO : ScriptableObject
    {
        public AudioClip ClickButtonSound;
        public AudioClip PlayerDamageSound;
        public AudioClip EnemyDieSound;
        public AudioClip CrossbowShotSound;
        public AudioClip MortalShotSound;
        public AudioClip CrystalShotSound;
        public AudioClip TeslaShotSound;
    }
}