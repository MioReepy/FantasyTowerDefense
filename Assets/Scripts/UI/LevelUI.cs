using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class LevelUI : WindowBase
    {
        [SerializeField] private Button _settingsButton;
        public override WindowType Type => WindowType.LevelUI;
        
        private void Awake()
        {
            _settingsButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            Time.timeScale = 0;
            UISystem.Instance.OpenWindow(WindowType.Settings);
        }
    }
}