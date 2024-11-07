using UnityEngine;

namespace UISpace
{
    public enum WindowType
    {
        MainMenu = 0,
        Settings = 1,
        LevelUI = 2,
        Pause = 3,
    }
    
    public abstract class WindowBase : MonoBehaviour
    {
        public abstract WindowType Type { get; }

        protected UISystem UISystem => UISystem.Instance;
        public bool IsOpen { get; set; }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}