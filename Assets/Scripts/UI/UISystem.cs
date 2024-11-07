using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UISpace
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private WindowBase[] _windows;
        internal List<WindowBase> openedWindows;

        public static UISystem Instance;
        private void Awake() => Instance = this;

        private void Start()
        {
            openedWindows = new List<WindowBase>();
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
            openedWindows.Add(windowToOpen);
        }

        public void Close(WindowType windowType)
        {
            var windowToClose = _windows.First(x => x.Type == windowType);

            var indexOf = openedWindows.IndexOf(windowToClose);

            openedWindows[indexOf].Close();
            openedWindows.Remove(openedWindows[indexOf]);
        }
    }
}