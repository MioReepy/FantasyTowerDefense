using UISpace;
using UnityEngine;

namespace SceneSpase
{
    public class LogoCreator : MonoBehaviour
    {
        [SerializeField] private float _timer = 3;
        
        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                Loader.Load(Loader.Scene.MainMenu, false,true);
            }
        }
    }
}