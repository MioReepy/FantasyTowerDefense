using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UISpace
{
    public class UISystem : MonoBehaviour
    {
        public static UISystem Instance;
        [SerializeField] private WindowBase[] _windows;

        private List<WindowBase> _openedWindows;
        private WindowBase _currentWindow;

        private void Awake() => Instance = this;

        private void Start()
        {
            _openedWindows = new List<WindowBase>();
            _windows = GetComponentsInChildren<WindowBase>(true);

            foreach (var window in _windows)
            {
                window.Close();
            }
        }

        public void OpenWindow(WindowType windowType)
        {
            var windowToOpen = _windows.First(x => x.Type == windowType);
            
            windowToOpen.transform.SetAsLastSibling();

            windowToOpen.Open();
            _currentWindow = windowToOpen;
            _openedWindows.Add(windowToOpen);
        }

        public void Close(WindowType windowType)
        {
            var windowToClose = _windows.First(x => x.Type == windowType);

            var indexOf = _openedWindows.IndexOf(windowToClose);

            _openedWindows[indexOf].Close();
            _openedWindows.Remove(_openedWindows[indexOf]);
            _currentWindow = _openedWindows[^1];
        }
    }
}