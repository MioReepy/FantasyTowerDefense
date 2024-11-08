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
        }

        private void OnCloseButtonClick()
        {
            UISystem.Instance.Close(WindowType.Settings);
            Time.timeScale = 1;
            AudioSource.PlayClipAtPoint(_audioClip.ClickButtonSound, Camera.main.transform.position, 1f);
        }
    }
}