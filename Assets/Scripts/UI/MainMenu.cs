using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class MainMenu : WindowBase
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _exitButton;
        
        public override WindowType Type => WindowType.MainMenu;

        private void Awake()
        {
               
            _playButton.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.GameScene, true,true);
            });
            
            _optionsButton.onClick.AddListener(OnSettingsButtonClick);
            
            _exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

        private void OnSettingsButtonClick()
        {
            UISystem.Instance.OpenWindow(WindowType.Settings);
        }
    }
}