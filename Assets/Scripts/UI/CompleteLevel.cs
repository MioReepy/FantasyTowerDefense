using System;
using PlayerSpace;
using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class CompleteLevel : WindowBase
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Image[] _stars;

        public override WindowType Type => WindowType.CompleteLevel;
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _quitButton.onClick.AddListener(OnQuitButtonClick);
            _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        }

        private void Start()
        {
            int lifes = PlayerStats.Instance.lifes;

            if (lifes < 1)
            {
                return;
            }
            if (lifes > 1)
            {
                _stars[0].gameObject.SetActive(true);
            }
            
            if (lifes >= 3)
            {
                _stars[1].gameObject.SetActive(true);
            }
            
            if (lifes == 5)
            {
                _stars[2].gameObject.SetActive(true);
            }
        }

        private void OnRestartButtonClick()
        {
            Loader.Load(Loader.Scene.GameScene, true,true);
        }

        private void OnQuitButtonClick()
        {
            Loader.Load(Loader.Scene.MainMenu, true,true);
        }

        private void OnNextLevelButtonClick()
        {
            Loader.Load(Loader.Scene.MainMenu, true,true);
        }
    }
}