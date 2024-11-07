using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class GameOver : WindowBase
    {
        [SerializeField] private Button _quitButton;
        [SerializeField] private Button _restartButton;

        public override WindowType Type => WindowType.GameOver;
        
        private void Awake()
        {
            _quitButton.onClick.AddListener(OnQuitButtonClick);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnQuitButtonClick()
        {
            Loader.Load(Loader.Scene.MainMenu, true,true);
            Time.timeScale = 1;
        }

        private void OnRestartButtonClick()
        {
            Loader.Load(Loader.Scene.GameScene, true,true);
            Time.timeScale = 1;
        }
    }
}