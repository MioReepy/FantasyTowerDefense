using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene("MainMenu");   
            }
        }
    }
}