using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UISpace
{
    public class PauseWindow : WindowBase
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        
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
        }

        private void OnRestartButtonClick()
        {
            SceneManager.LoadSceneAsync("GameScene");
            SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
        }

        private void OnQuitButtonClick()
        {
            SceneManager.LoadSceneAsync("MainMenu");
            SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
        }
    }
}