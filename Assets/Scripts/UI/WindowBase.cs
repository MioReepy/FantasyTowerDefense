using UnityEngine;

namespace UISpace
{
    public enum WindowType
    {
        MainMenu = 0,
        Settings = 1,
        LevelUI = 2,
        SelectStage = 3,
        GameWindow = 4,
        StartLevel = 5,
        CompleteLevel = 6,
        ReatartLevel = 7,
    }
    
    public abstract class WindowBase : MonoBehaviour
    {
        public abstract WindowType Type { get; }

        protected UISystem UISystem => UISystem.Instance;

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}