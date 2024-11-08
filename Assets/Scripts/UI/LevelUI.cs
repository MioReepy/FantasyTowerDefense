using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _pauseButton;
        
        private void Awake()
        {
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        private void OnPauseButtonClick()
        {
            UISystem.Instance.OpenWindow(WindowType.Pause);
            Time.timeScale = 0;
        }

        private void OnSettingsButtonClick()
        {
            Time.timeScale = 0;
            UISystem.Instance.OpenWindow(WindowType.Settings);
        }
    }
}