using MusicSpase;
using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class Settings : WindowBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _soundVolumeSlider;
        [SerializeField] private AudioClipSO _audioClip;
        
        public override WindowType Type => WindowType.Settings;
        
        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
            _musicVolumeSlider.onValueChanged.AddListener(OnChangeMusicVolume);
            _soundVolumeSlider.onValueChanged.AddListener(OnChangeSoundVolume);
            _musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicManager.PrefsMusicEffectVolume, 0.5f);
        }

        private void Start()
        {
            _soundVolumeSlider.value = PlayerPrefs.GetFloat(SoundManager.PrefsSoundEffectVolume, 0.5f);
        }

        private void OnChangeSoundVolume(float value)
        {
            SoundManager.Instance.ChangeSoundVolume(value);
        }
        
        private void OnChangeMusicVolume(float value)
        {
            MusicManager.Instance.ChangeMusicVolume(value);
        }

        private void OnCloseButtonClick()
        {
            UISystem.Instance.Close(WindowType.Settings);
            Time.timeScale = 1;
            AudioSource.PlayClipAtPoint(_audioClip.ClickButtonSound, Camera.main.transform.position, _soundVolumeSlider.value);
        }
    }
}