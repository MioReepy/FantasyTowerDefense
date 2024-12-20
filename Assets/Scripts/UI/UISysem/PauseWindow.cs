using MusicSpase;
using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class PauseWindow : WindowBase
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private AudioClipSO _audioClip;
        public override WindowType Type => WindowType.Pause;
        
        private void Awake()
        {
            _continueButton.onClick.AddListener(OnContinueButtonClick);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _quitButton.onClick.AddListener(OnQuitButtonClick);
        }

        private void OnContinueButtonClick()
        {
            UISystem.Instance.Close(WindowType.Pause);
            Time.timeScale = 1;
            AudioSource.PlayClipAtPoint(_audioClip.ClickButtonSound, Camera.main.transform.position, PlayerPrefs.GetFloat(SoundManager.PrefsSoundEffectVolume, 0.5f));
        }

        private void OnRestartButtonClick()
        {
            Loader.Load(Loader.Scene.GameScene, true,true);
        }

        private void OnQuitButtonClick()
        {
            Loader.Load(Loader.Scene.MainMenu, true,true);
        }
    }
}